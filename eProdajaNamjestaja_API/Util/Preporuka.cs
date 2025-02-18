﻿using eProdajaNamjestaja_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eProdajaNamjestaja_API.Util
{
    public class Preporuka
    {
        Dictionary<int?, List<Ocjene>> proizvodi = new Dictionary<int?, List<Ocjene>>();
        private eNamjestajEntities db = new eNamjestajEntities();


        public List<esp_Proizvodi_SelectById_Result> GetSlicneProizvode(int proizvodId)
        {
            UcitajProizvode(proizvodId);
            List<Ocjene> ocjenePosmatranogProizvoda = db.Ocjene.Where(x => x.ProizvodID == proizvodId).OrderBy(x => x.KupacID).ToList();

            List<Ocjene> zajednickeOcjene1 = new List<Ocjene>();
            List<Ocjene> zajednickeOcjene2 = new List<Ocjene>();

            List<esp_Proizvodi_SelectById_Result> preporuceno = new List<esp_Proizvodi_SelectById_Result>();


            foreach (var item in proizvodi)
            {
                foreach (Ocjene o in ocjenePosmatranogProizvoda)
                {

                    if (item.Value.Where(x => x.KupacID == o.KupacID).Count() > 0)
                    {
                        zajednickeOcjene1.Add(o);
                        zajednickeOcjene2.Add(item.Value.Where(x => x.KupacID == o.KupacID).First());
                    }
                }


                double slicnost = GetSlicnost(zajednickeOcjene1, zajednickeOcjene2);
                if (slicnost > 0.6)
                    preporuceno.Add(db.esp_Proizvodi_SelectById(item.Key).FirstOrDefault());


                zajednickeOcjene1.Clear();
                zajednickeOcjene2.Clear();
            }


            return preporuceno;
        }


        private void UcitajProizvode(int proizvodId)
        {
            List<Proizvodi> aktivniProizvodi = db.Proizvodi.Where(x => x.Statuss == true && x.ProizvodID != proizvodId).ToList();

            List<Ocjene> ocjene;
            foreach (Proizvodi p in aktivniProizvodi)
            {
                ocjene = db.Ocjene.Where(x => x.ProizvodID == p.ProizvodID).OrderBy(x => x.KupacID).ToList();
                if (ocjene.Count > 0)
                    proizvodi.Add(p.ProizvodID, ocjene);

            }
        }


        double GetSlicnost(List<Ocjene> ocjene1, List<Ocjene> ocjene2)
        {
            if (ocjene1.Count != ocjene2.Count)
                return 0;

            int brojnik = 0;
            double nazivnik1 = 0;
            double nazivnik2 = 0;

            for (int i = 0; i < ocjene1.Count; i++)
            {
                brojnik += ocjene1[i].Ocjena * ocjene2[i].Ocjena;
                nazivnik1 += ocjene1[i].Ocjena * ocjene1[i].Ocjena;
                nazivnik2 += ocjene2[i].Ocjena * ocjene2[i].Ocjena;
            }

            nazivnik1 = Math.Sqrt(nazivnik1);
            nazivnik2 = Math.Sqrt(nazivnik2);

            double nazivnik = nazivnik1 * nazivnik2;

            if (nazivnik != 0)
                return brojnik / nazivnik;

            return 0;

        }
    }

}