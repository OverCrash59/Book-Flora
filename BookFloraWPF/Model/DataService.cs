using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using HtmlAgilityPack;
using Newtonsoft.Json;

namespace BookFloraWPF.Model
{
    public class DataService : IDataService
    { 
        const string baseAdress = "https://fr.wikipedia.org/w/api.php?action=query&format=json&prop=revisions&redirects=1&utf8=1&formatversion=latest&rvprop=content&rvexpandtemplates=1&rvparse=1&rvcontentformat=text%2Fplain&titles=";

        public void GetData(Action<List<TileSpecies>, Exception> callback)
        {
            // Use this to connect to the actual data service
            using (var db = new FloraModel())
            {
                var speciesList = (from s in db.Specieses select s).ToList();

                var tileSpeciesList = new List<TileSpecies>();

                foreach (var species in speciesList)
                {
                    var t = new TileSpecies();
                    t.SpeciesId = species.SpeciesId;
                    t.Binomial = species.BinomialName;
                    t.CommonName = species.CommonName;
                    try
                    {
                        var p = species.Photos.First();
                        t.PhotoId = p.PhotoId;
                        t.PhotoUrl = p.Url;

                    }
                    catch (Exception ex)
                    {
                        
                    }

                    tileSpeciesList.Add(t);
                }

                callback(tileSpeciesList, null);
            }
        }

        public SpeciesSelected GetSpecies(string query)
        {
            SpeciesSelected ss;
            using (var db = new FloraModel())
            {
                try
                {
                    var species =(from s in db.Specieses where s.CommonName == query || s.BinomialName == query select s).First();

                    ss = new SpeciesSelected
                    {
                        Species = species,
                        Photo = db.Photos.Single(p => p.SpeciesForeignKey == species.SpeciesId),
                        Genus = db.Genera.Single(g => g.GenusId == species.GenusForeignKey)
                    };
                    ss.Family = db.Families.Single(f => f.FamilyId == ss.Genus.FamilyForeignKey);
                        ss.Order = db.Orders.Single(o => o.OrderId == ss.Family.OrderForeignKey);
                        ss.Classe = db.Classes.Single(c => c.ClasseId == ss.Order.ClasseForeignKey);
                        ss.Phylum = db.Phylums.Single(p => p.PhylumId == ss.Classe.PhylumForeignKey);
                        ss.Kingdom = db.Kingdoms.Single(k => k.KingdomId == ss.Phylum.KingdomForeignKey);
                        return ss;

                }
                catch (Exception)
                {

                    return null;
                }
            }
        }

        public SpeciesSelected GetSpeciesByWiki(string adresse)
        {
            var ss = new SpeciesSelected();
            var query = ConvertString(adresse);

            var responseText = GetResponse(query);

            var root = JsonConvert.DeserializeObject<RootObject>(responseText);
            if (root.query.pages[0].revisions != null)
            {
                ss = FillFlore(root);

            }
            return ss;

        }

        private static string ConvertString(string query)
        {
            return (baseAdress + query.Replace(' ', '+'));
        }

        public Uri GetUriWiki(string query)
        {
            return new Uri("https://fr.wikipedia.org/wiki/" + query.Replace(' ', '_'));
        }

        private static string GetResponse(string query)
        {
            string responseText;

            var myRequest = (HttpWebRequest)WebRequest.Create(baseAdress + query);

            using (var response = (HttpWebResponse)myRequest.GetResponse())
            {
                if (response.GetResponseStream() != null)
                {
                    using (var reader = new StreamReader(response.GetResponseStream(), encoding: Encoding.UTF8))
                    {
                        responseText = reader.ReadToEnd();
                    }

                }
                else
                {
                    responseText = string.Empty;
                }
            }

            return responseText;
        }

        private static SpeciesSelected FillFlore(RootObject root)
        {
            var flore = new SpeciesSelected();

            var content = root.query.pages[0].revisions[0].content;
            var source = content;
            source = WebUtility.HtmlDecode(source);
            var resultat = new HtmlDocument();
            resultat.LoadHtml(source);

            var toftitle = resultat.DocumentNode.Descendants().Where
                (x => (x.Name == "div" && x.Attributes["class"] != null &&
                x.Attributes["class"].Value.Contains("entete"))).ToList();
            flore.Species = new Species();
            flore.Species.BinomialName = toftitle[0].Descendants("i").ToList()[0].InnerText;

            toftitle = resultat.DocumentNode.Descendants().Where
                (x => (x.Name == "div" && x.Attributes["class"] != null &&
                x.Attributes["class"].Value.Contains("images"))).ToList();

            var urlPhoto = toftitle[0].Descendants("img").ToList()[0].Attributes["src"].Value;
            flore.Photo = new Photo();
            flore.Photo.Url = "https:" + urlPhoto;

            toftitle = resultat.DocumentNode.Descendants().Where
                (x => (x.Name == "table" && x.Attributes["class"] != null &&
                x.Attributes["class"].Value.Contains("taxobox_classification"))).ToList();

            //var table = toftitle[0].Descendants("tbody").ToList()[0];

            foreach (var item in toftitle[0].Descendants("tr"))
            {
                var a = item.Descendants("a").ToList()[0].InnerText;
                switch (a)
                {
                    case "Règne":
                        flore.Kingdom = new Kingdom();
                        var kname = item.Descendants("a").ToList()[1].InnerText;
                        flore.Kingdom = !Kingdom.IsExist(kname) ? Kingdom.GetKingdom(kname) : Kingdom.GetKingdom(kname);
                        break;
                    case "Division":
                        flore.Phylum = new Phylum();
                        var pname = item.Descendants("a").ToList()[1].InnerText;
                        flore.Phylum = !Phylum.IsExist(pname) ? new Phylum {Name = pname} : Phylum.GetPhylum(pname);
                        break;
                    case "Classe":
                        flore.Classe = new Classe();
                        var cname = item.Descendants("a").ToList()[1].InnerText;
                        flore.Classe = !Classe.IsExist(cname) ? new Classe {Name = cname} : Classe.GetClasse(cname);
                        break;
                    case "Ordre":
                        flore.Order = new Order();
                        var oname = item.Descendants("a").ToList()[1].InnerText;
                        flore.Order = !Order.IsExist(oname) ? new Order {Name = oname} : Order.GetOrder(oname);
                        break;
                    case "Famille":
                        flore.Family = new Family();
                        var fname = item.Descendants("a").ToList()[1].InnerText;
                        flore.Family = !Family.IsExist(fname) ? new Family {Name = fname} : Family.GetFamily(fname);
                        break;
                    case "Genre":
                        flore.Genus = new Genus();
                        var gname = item.Descendants("a").ToList()[1].InnerText;
                        flore.Genus = !Genus.IsExist(gname) ? new Genus {Name = gname} : Genus.GetGenus(gname);
                        break;
                    default:
                        break;
                }
            }
            flore.Species.Photos = new List<Photo> {flore.Photo};
            flore.Genus.Specieses = new List<Species> {flore.Species};
            flore.Family.Genera = new List<Genus> {flore.Genus};
            flore.Order.Families = new List<Family> {flore.Family};
            flore.Classe.Orders = new List<Order> {flore.Order};
            flore.Phylum.Classes = new List<Classe> {flore.Classe};
            flore.Kingdom.Phylums = new List<Phylum> {flore.Phylum};
            return flore;
        }

        public void Save(SpeciesSelected speciesSelected)
        {
            //Kingdom.SaveKingdom(speciesSelected.Kingdom);
            //Phylum.Save(speciesSelected.Phylum);
            //Classe.Save(speciesSelected.Classe);
            //Order.Save(speciesSelected.Order);
            //Family.Save(speciesSelected.Family);
            //Genus.Save(speciesSelected.Genus);
            //Species.Save(speciesSelected.Species);
            //Photo.Save(speciesSelected.Photo);

            using (var db = new FloraModel())
            {
                db.Kingdoms.AddOrUpdate(speciesSelected.Kingdom);
                db.Phylums.AddOrUpdate(speciesSelected.Phylum);
                db.Classes.AddOrUpdate(speciesSelected.Classe);
                db.Orders.AddOrUpdate(speciesSelected.Order);
                db.Families.AddOrUpdate(speciesSelected.Family);
                db.Genera.AddOrUpdate(speciesSelected.Genus);
                db.Specieses.AddOrUpdate(speciesSelected.Species);
                db.Photos.AddOrUpdate(speciesSelected.Photo);
                db.SaveChanges();
            }

        }

    }
}