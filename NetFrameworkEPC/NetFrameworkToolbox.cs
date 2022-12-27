using DynobilV3.Entities.Concrete;
using System;
using System.Drawing;
using ZedGraph;

namespace NetFrameworkEPC
{
    public class NetFrameworkToolbox
    {
        public System.Drawing.Image SetGraphForDyno(Araba val)
        {
            try
            {
                ZedGraphControl zedGraph = new ZedGraphControl();
                zedGraph.GraphPane.Chart.Fill.Color = Color.FromArgb(100, 203, 203, 203);
                zedGraph.GraphPane.Fill.Color = Color.FromArgb(100, 203, 203, 203);
                zedGraph.GraphPane.Border.Width = 0;
                zedGraph.GraphPane.Chart.Border.Width = 0;
                zedGraph.IsShowCursorValues = false;
                zedGraph.GraphPane.Border.IsVisible = false;
                zedGraph.GraphPane.Chart.Border.IsVisible = false;

                //zedGraphControl1.GraphPane.Border = null;
                //zedGraphControl1.GraphPane.Border = null; 
                //  PointPairList KwCizim = new PointPairList();
                PointPairList HpCizim = new PointPairList();
                PointPairList KayipCizim = new PointPairList();
                PointPairList TorkCizim = new PointPairList();
                PointPairList DevirCizim = new PointPairList();
                // PointPairList Kw_4wdCizim = new PointPairList();
                PointPairList Hp_4wdCizim = new PointPairList();
                PointPairList Kayip4wdCizim = new PointPairList();
                PointPairList Tork_4wdCizim = new PointPairList();
                PointPairList Devir_4wdCizim = new PointPairList();
                LineItem HpCiz, TorkCiz, KayipCiz, Hp4wdCiz, Tork4wdCiz, Kayip4wdCiz, DevirCiz, Devir4wdCiz;
                GraphPane myPane = new GraphPane();
                myPane = zedGraph.GraphPane;
                myPane.Title.Text = "Dyno Testi Grafiği";
                myPane.XAxis.Title.Text = "Devir (RPM)";
                myPane.YAxis.Title.Text = "Güç (HP)";
                myPane.Y2Axis.Title.Text = "Tork (Nm)";
                myPane.Y2Axis.IsVisible = true;
                try
                {
                    for (int i = 0; i < val.Dinamometre.Hiz.Split(',').Length; i++)
                    {

                        //arrayhp[rowsayar] = Convert.ToInt32(csDynoTesti.Sirala.Rows[rowsayar]["hp"]);
                        try
                        {
                            HpCizim.Add(Convert.ToInt32(val.Dinamometre.Devir.Split(',')[i]), Convert.ToInt32(val.Dinamometre.GucHP.Split(',')[i]));
                            KayipCizim.Add(Convert.ToInt32(val.Dinamometre.Devir.Split(',')[i]), Convert.ToInt32(Convert.ToInt32(val.Dinamometre.KayipGuc.Split(',')[i])));
                            TorkCizim.Add(Convert.ToInt32(val.Dinamometre.Devir.Split(',')[i]), Convert.ToInt32(val.Dinamometre.Tork.Split(',')[i]));
                            //DevirCizim.Add(Convert.ToInt32(csDynoTesti.Sirala.Rows[i]["rpm"]), 0);
                        }
                        catch (Exception)
                        {
                        }
                    }
                    HpCiz = myPane.AddCurve("OnTekerGucu", HpCizim, Color.Blue, SymbolType.None);
                    TorkCiz = myPane.AddCurve("Tork On", TorkCizim, Color.Red, SymbolType.None);
                    KayipCiz = myPane.AddCurve("Kayip On", KayipCizim, Color.Black, SymbolType.None);
                }
                catch (Exception)
                {

                }
                try
                {
                    for (int i = 0; i < val.Dinamometre.Hiz4wd.Split(',').Length; i++)
                    {
                        try
                        {

                            Hp_4wdCizim.Add(Convert.ToInt32(val.Dinamometre.Devir4wd.Split(',')[i]), Convert.ToInt32(val.Dinamometre.GucHP4wd.Split(',')[i]));
                            Kayip4wdCizim.Add(Convert.ToInt32(val.Dinamometre.Devir4wd.Split(',')[i]), Convert.ToInt32(Convert.ToInt32(val.Dinamometre.KayipGuc4wd.Split(',')[i])));
                            Tork_4wdCizim.Add(Convert.ToInt32(val.Dinamometre.Devir4wd.Split(',')[i]), Convert.ToInt32(val.Dinamometre.Tork4wd.Split(',')[i]));
                        }
                        catch (Exception)
                        {
                        }
                    }
                    Hp4wdCiz = myPane.AddCurve("ArkaTekerGucu", Hp_4wdCizim, Color.Purple, SymbolType.None);
                    Kayip4wdCiz = myPane.AddCurve("Kayıp Arka", Kayip4wdCizim, Color.DarkOrange, SymbolType.None);
                    Tork4wdCiz = myPane.AddCurve("Tork Arka", Tork_4wdCizim, Color.Green, SymbolType.None);
                }
                catch (Exception)
                {

                }
                try
                {
                    ((LineItem)myPane.CurveList[0]).Line.Width = 2.0f;
                    ((LineItem)myPane.CurveList[1]).Line.Width = 2.0f;
                    ((LineItem)myPane.CurveList[2]).Line.Width = 2.0f;
                    ((LineItem)myPane.CurveList[3]).Line.Width = 2.0f;
                    ((LineItem)myPane.CurveList[4]).Line.Width = 2.0f;
                    ((LineItem)myPane.CurveList[5]).Line.Width = 2.0f;
                    ((LineItem)myPane.CurveList[6]).Line.Width = 2.0f;
                    ((LineItem)myPane.CurveList[7]).Line.Width = 2.0f;
                    ((LineItem)myPane.CurveList[8]).Line.Width = 2.0f;

                }
                catch (Exception)
                {
                }
                try
                {
                    ((LineItem)myPane.CurveList[0]).Line.IsSmooth = true;
                    ((LineItem)myPane.CurveList[1]).Line.IsSmooth = true;
                    ((LineItem)myPane.CurveList[2]).Line.IsSmooth = true;
                    ((LineItem)myPane.CurveList[3]).Line.IsSmooth = true;
                    ((LineItem)myPane.CurveList[4]).Line.IsSmooth = true;
                    ((LineItem)myPane.CurveList[5]).Line.IsSmooth = true;
                    ((LineItem)myPane.CurveList[6]).Line.IsSmooth = true;
                    ((LineItem)myPane.CurveList[7]).Line.IsSmooth = true;
                    ((LineItem)myPane.CurveList[8]).Line.IsSmooth = true;
                }
                catch (Exception)
                {
                }
                try
                {
                    ((LineItem)myPane.CurveList[0]).Line.SmoothTension = 0.5F;
                    ((LineItem)myPane.CurveList[1]).Line.SmoothTension = 0.5F;
                    ((LineItem)myPane.CurveList[2]).Line.SmoothTension = 0.5F;
                    ((LineItem)myPane.CurveList[3]).Line.SmoothTension = 0.5F;
                    ((LineItem)myPane.CurveList[4]).Line.SmoothTension = 0.5F;
                    ((LineItem)myPane.CurveList[5]).Line.SmoothTension = 0.5F;
                    ((LineItem)myPane.CurveList[6]).Line.SmoothTension = 0.5F;
                    ((LineItem)myPane.CurveList[7]).Line.SmoothTension = 0.5F;
                    ((LineItem)myPane.CurveList[8]).Line.SmoothTension = 0.5F;
                }
                catch { }
                //zedGraph.Invalidate();
                //zedGraph.AxisChange();
                //zedGraph.Refresh();
                //System.Drawing.Image graf = zedGraph.GetImage();
                //var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\DinamometreGraphs", val.Id.ToString());
                //graf.Save(path);
                //using (var stream = new FileStream(path, FileMode.Create))
                //{
                //}
                return zedGraph.GetImage();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
