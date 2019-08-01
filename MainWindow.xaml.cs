using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sudoku
{

    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int[,] felder = new int[9, 9];
        private List<int> list = new List<int>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {

            feld1.Text = "0";
            feld2.Text = "0";
            feld3.Text = "0";
            feld4.Text = "0";
            feld5.Text = "0";
            feld6.Text = "0";
            feld7.Text = "0";
            feld8.Text = "0";
            feld9.Text = "0";
            feld10.Text = "0";
            feld11.Text = "0";
            feld12.Text = "0";
            feld13.Text = "0";
            feld14.Text = "0";
            feld15.Text = "0";
            feld16.Text = "0";
            feld17.Text = "0";
            feld18.Text = "0";
            feld19.Text = "0";
            feld20.Text = "0";
            feld21.Text = "0";
            feld22.Text = "0";
            feld23.Text = "0";
            feld24.Text = "0";
            feld25.Text = "0";
            feld26.Text = "0";
            feld27.Text = "0";
            feld28.Text = "0";
            feld29.Text = "0";
            feld30.Text = "0";
            feld31.Text = "0";
            feld32.Text = "0";
            feld33.Text = "0";
            feld34.Text = "0";
            feld35.Text = "0";
            feld36.Text = "0";
            feld37.Text = "0";
            feld38.Text = "0";
            feld39.Text = "0";
            feld40.Text = "0";
            feld41.Text = "0";
            feld42.Text = "0";
            feld43.Text = "0";
            feld44.Text = "0";
            feld45.Text = "0";
            feld46.Text = "0";
            feld47.Text = "0";
            feld48.Text = "0";
            feld49.Text = "0";
            feld50.Text = "0";
            feld51.Text = "0";
            feld52.Text = "0";
            feld53.Text = "0";
            feld54.Text = "0";
            feld55.Text = "0";
            feld56.Text = "0";
            feld57.Text = "0";
            feld58.Text = "0";
            feld59.Text = "0";
            feld60.Text = "0";
            feld61.Text = "0";
            feld62.Text = "0";
            feld63.Text = "0";
            feld64.Text = "0";
            feld65.Text = "0";
            feld66.Text = "0";
            feld67.Text = "0";
            feld68.Text = "0";
            feld69.Text = "0";
            feld70.Text = "0";
            feld71.Text = "0";
            feld72.Text = "0";
            feld73.Text = "0";           
            feld74.Text = "0";
            feld75.Text = "0";
            feld76.Text = "0";
            feld77.Text = "0";
            feld78.Text = "0";
            feld79.Text = "0";
            feld80.Text = "0";
            feld81.Text = "0";





        }

        private void SolveBtn_Click(object sender, RoutedEventArgs e)
        {
            GetInputToArray();

            for(int i = 0; i < 1000; i++)
            {
                SimplePruefer();
                CheckZahl();

                if (CheckFertig())
                {
                    break;
                }

            }
            GetArrayToOutput(felder);
        }


        public void FillList()
        {
            list.Clear();
            for(int i = 1; i < 10; i++)
            {
                
                list.Add(i);
                
            }

        }

        public void CheckZahl()
        {
            for(int y=0; y < 9; y++)
            {
                for(int x=0; x<9; x++)
                {
                    
                    if (felder[y, x] == 0)
                    {
                        FillList(); //Liste mit 1 bis 9 füllen

                        //horizontal
                        for(int xw = 0; xw < 9; xw++)
                        {
                            if (list.Contains(felder[y, xw]))
                            {
                                list.Remove(felder[y, xw]);
                            }
                        }

                        //vertikal
                        for (int yw = 0; yw < 9; yw++)
                        {
                            if (list.Contains(felder[yw, x]))
                            {
                                list.Remove(felder[yw, x]);
                            }
                        }

                        // 1. Kästchen

                        if ((x <= 2) && (y <= 2))
                        {
                            for (int i = 0; i <= 2; i++)
                            {
                                for (int j = 0; j <= 2; j++)
                                {
                                    if (list.Contains(felder[i, j]))
                                    {
                                        list.Remove(felder[i, j]);
                                    }
                                    
                                }
                            }
                        }

                        // 2. Kästchen
                        else if ((x > 2) && (y <= 2) && (x <= 5))
                        {
                            for (int i = 0; i <= 2; i++)
                            {
                                for (int j = 3; j <= 5; j++)
                                {

                                    if (list.Contains(felder[i, j]))
                                    {
                                        list.Remove(felder[i, j]);
                                    }
                                }
                            }
                        }

                        // 3. Kästchen
                        else if ((x > 5) && (y <= 2) && (x <= 8))
                        {
                            for (int i = 0; i <= 2; i++)
                            {
                                for (int j = 6; j <= 8; j++)
                                {

                                    if (list.Contains(felder[i, j]))
                                    {
                                        list.Remove(felder[i, j]);
                                    }
                                }
                            }
                        }

                        // 4. Kästchen
                        else if ((y <= 5) && (y > 2) && (x <= 2))
                        {
                            for (int i = 3; i <= 5; i++)
                            {
                                for (int j = 0; j <= 2; j++)
                                {

                                    if (list.Contains(felder[i, j]))
                                    {
                                        list.Remove(felder[i, j]);
                                    }
                                }
                            }
                        }

                        // 5. Kästchen
                        else if ((x > 2) && (y <= 5) && (x <= 5) && (y > 2))
                        {
                            for (int i = 3; i <= 5; i++)
                            {
                                for (int j = 3; j <= 5; j++)
                                {

                                    if (list.Contains(felder[i, j]))
                                    {
                                        list.Remove(felder[i, j]);
                                    }
                                }
                            }
                        }

                        // 6. Kästchen
                        else if ((y > 2) && (y <= 5) && (x > 5))
                        {
                            for (int i = 3; i <= 5; i++)
                            {
                                for (int j = 6; j <= 8; j++)
                                {

                                    if (list.Contains(felder[i, j]))
                                    {
                                        list.Remove(felder[i, j]);
                                    }
                                }
                            }
                        }

                        // 7.Kästchen
                        else if ((y > 5) && (x <= 2))
                        {
                            for (int i = 6; i <= 8; i++)
                            {
                                for (int j = 0; j <= 2; j++)
                                {

                                    if (list.Contains(felder[i, j]))
                                    {
                                        list.Remove(felder[i, j]);
                                    }
                                }
                            }
                        }

                        // 8.Kästchen
                        else if ((x > 2) && (y > 5) && (x <= 5))
                        {
                            for (int i = 6; i <= 8; i++)
                            {
                                for (int j = 3; j <= 5; j++)
                                {

                                    if (list.Contains(felder[i, j]))
                                    {
                                        list.Remove(felder[i, j]);
                                    }
                                }
                            }
                        }

                        // 9.Kästchen
                        else if ((x > 5) && (y > 5))
                        {
                            for (int i = 6; i <= 8; i++)
                            {
                                for (int j = 6; j <= 8; j++)
                                {

                                    if (list.Contains(felder[i, j]))
                                    {
                                        list.Remove(felder[i, j]);
                                    }
                                }
                            }
                        }



                        if (list.Count == 1)
                        {
                            felder[y, x] = list.ElementAt(0);
                        }




























                    }









                }
            }

        }



        public bool Check(int zahl, int y, int x)
        {
            int anzahl = 0;
            int vertikalanzahl = 0;
            int horizontalanzahl = 0;

            // Horizontale Überprüfung

            for (int xw = 0; xw < 9; xw++)
            {

                if (felder[y,xw] == zahl)
                {
                    return false;
                }
                else if ((felder[y,xw] > 0) && (xw != x))
                {
                    horizontalanzahl++;
                }

                if (horizontalanzahl == 8)
                {
                    return true;
                }
            }

            // Vermutlich folgt hier die Analyse für fortgeschrittene Level

            // Vertikale Überprüfung

            for (int yw = 0; yw < 9; yw++)
            {

                if (felder[yw,x] == zahl)
                {
                    return false;
                }
                else if ((felder[yw,x] > 0) && (yw != y))
                {
                    vertikalanzahl++;
                }

                if (vertikalanzahl == 8)
                {
                    return true;
                }

            }
            // 1. Kästchen

            if ((x <= 2) && (y <= 2))
            {
                for (int i = 0; i <= 2; i++)
                {
                    for (int j = 0; j <= 2; j++)
                    {

                        if ((felder[i,j] > 0) && (felder[i,j] != zahl))
                        {
                            anzahl++;
                        }
                        else if (felder[i,j] == zahl)
                        {
                            return false;
                        }

                        if (anzahl == 8)
                        {
                            return true;
                        }
                    }
                }
            }

            // 2. Kästchen
            else if ((x > 2) && (y <= 2) && (x <= 5))
            {
                for (int i = 0; i <= 2; i++)
                {
                    for (int j = 3; j <= 5; j++)
                    {

                        if ((felder[i,j] > 0) && (felder[i,j] != zahl))
                        {
                            anzahl++;
                        }
                        else if (felder[i,j] == zahl)
                        {
                            return false;
                        }

                        if (anzahl == 8)
                        {
                            return true;
                        }
                    }
                }
            }

            // 3. Kästchen
            else if ((x > 5) && (y <= 2) && (x <= 8))
            {
                for (int i = 0; i <= 2; i++)
                {
                    for (int j = 6; j <= 8; j++)
                    {

                        if ((felder[i,j] > 0) && (felder[i,j] != zahl))
                        {
                            anzahl++;
                        }
                        else if (felder[i,j] == zahl)
                        {
                            return false;
                        }

                        if (anzahl == 8)
                        {
                            return true;
                        }
                    }
                }
            }

            // 4. Kästchen
            else if ((y <= 5) && (y > 2) && (x <= 2))
            {
                for (int i = 3; i <= 5; i++)
                {
                    for (int j = 0; j <= 2; j++)
                    {

                        if ((felder[i,j] > 0) && (felder[i,j] != zahl))
                        {
                            anzahl++;
                        }
                        else if (felder[i,j] == zahl)
                        {
                            return false;
                        }

                        if (anzahl == 8)
                        {
                            return true;
                        }
                    }
                }
            }

            // 5. Kästchen
            else if ((x > 2) && (y <= 5) && (x <= 5) && (y > 2))
            {
                for (int i = 3; i <= 5; i++)
                {
                    for (int j = 3; j <= 5; j++)
                    {

                        if ((felder[i,j] > 0) && (felder[i,j] != zahl))
                        {
                            anzahl++;
                        }
                        else if (felder[i,j] == zahl)
                        {
                            return false;
                        }

                        if (anzahl == 8)
                        {
                            return true;
                        }
                    }
                }
            }

            // 6. Kästchen
            else if ((y > 2) && (y <= 5) && (x > 5))
            {
                for (int i = 3; i <= 5; i++)
                {
                    for (int j = 6; j <= 8; j++)
                    {

                        if ((felder[i,j] > 0) && (felder[i,j] != zahl))
                        {
                            anzahl++;
                        }
                        else if (felder[i,j] == zahl)
                        {
                            return false;
                        }

                        if (anzahl == 8)
                        {
                            return true;
                        }
                    }
                }
            }

            // 7.Kästchen
            else if ((y > 5) && (x <= 2))
            {
                for (int i = 6; i <= 8; i++)
                {
                    for (int j = 0; j <= 2; j++)
                    {

                        if ((felder[i,j] > 0) && (felder[i,j] != zahl))
                        {
                            anzahl++;
                        }
                        else if (felder[i,j] == zahl)
                        {
                            return false;
                        }

                        if (anzahl == 8)
                        {
                            return true;
                        }
                    }
                }
            }

            // 8.Kästchen
            else if ((x > 2) && (y > 5) && (x <= 5))
            {
                for (int i = 6; i <= 8; i++)
                {
                    for (int j = 3; j <= 5; j++)
                    {

                        if ((felder[i,j] > 0) && (felder[i,j] != zahl))
                        {
                            anzahl++;
                        }
                        else if (felder[i,j] == zahl)
                        {
                            return false;
                        }

                        if (anzahl == 8)
                        {
                            return true;
                        }
                    }
                }
            }

            // 9.Kästchen
            else if ((x > 5) && (y > 5))
            {
                for (int i = 6; i <= 8; i++)
                {
                    for (int j = 6; j <= 8; j++)
                    {

                        if ((felder[i,j] > 0) && (felder[i,j] != zahl))
                        {
                            anzahl++;
                        }
                        else if (felder[i,j] == zahl)
                        {
                            return false;
                        }

                        if (anzahl == 8)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public void SimplePruefer()
        {

            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {

                    if (felder[y,x] == 0)
                    {
                        for (int zahl = 1; zahl < 10; zahl++)
                        {

                            if (Check(zahl, y, x))
                            {
                                felder[y,x] = zahl;
                            }
                        }

                    }

                }
            }
        }


        public bool CheckFertig()
        {
            int i = 0;
            if (Nullchecker() != 0)
            {
                return false;
            }

            // Vertikal
            for (int zahl = 1; zahl < 10; zahl++)
            {
                for (int x = 0; x < 9; x++)
                {
                    for (int y = 0; y < 9; y++)
                    {
                        if (felder[y,x] == zahl)
                        {
                            i++;
                        }


                    }
                    if (i > 1 || i < 1)
                    {
                        return false;
                    }
                    i = 0;
                }
                i = 0;
            }
            i = 0;

            // Horizontal
            for (int zahl = 1; zahl < 10; zahl++)
            {
                for (int y = 0; y < 9; y++)
                {
                    for (int x = 0; x < 9; x++)
                    {
                        if (felder[y,x] == zahl)
                        {
                            i++;
                        }


                    }
                    if (i > 1 || i < 1)
                    {
                        return false;
                    }
                    i = 0;
                }
                i = 0;
            }
            return true;

        }


        // Nullchecker Methode
        public int Nullchecker()
        {
            int res = 81;

            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (felder[y,x] != 0)
                    {
                        res--;
                    }
                }
            }
            return res;
        }








        public void GetArrayToOutput(int[,] array)
        {
            feld1.Text = array[0, 0].ToString();
            feld2.Text = array[0, 1].ToString();
            feld3.Text = array[0, 2].ToString();
            feld4.Text = array[0, 3].ToString();
            feld5.Text = array[0, 4].ToString();
            feld6.Text = array[0, 5].ToString();
            feld7.Text = array[0, 6].ToString();
            feld8.Text = array[0, 7].ToString();
            feld9.Text = array[0, 8].ToString();

            feld10.Text = array[1, 0].ToString();
            feld11.Text = array[1, 1].ToString();
            feld12.Text = array[1, 2].ToString();
            feld13.Text = array[1, 3].ToString();
            feld14.Text = array[1, 4].ToString();
            feld15.Text = array[1, 5].ToString();
            feld16.Text = array[1, 6].ToString();
            feld17.Text = array[1, 7].ToString();
            feld18.Text = array[1, 8].ToString();

            feld19.Text = array[2, 0].ToString();
            feld20.Text = array[2, 1].ToString();
            feld21.Text = array[2, 2].ToString();
            feld22.Text = array[2, 3].ToString();
            feld23.Text = array[2, 4].ToString();
            feld24.Text = array[2, 5].ToString();
            feld25.Text = array[2, 6].ToString();
            feld26.Text = array[2, 7].ToString();
            feld27.Text = array[2, 8].ToString();

            feld28.Text = array[3, 0].ToString();
            feld29.Text = array[3, 1].ToString();
            feld30.Text = array[3, 2].ToString();
            feld31.Text = array[3, 3].ToString();
            feld32.Text = array[3, 4].ToString();
            feld33.Text = array[3, 5].ToString();
            feld34.Text = array[3, 6].ToString();
            feld35.Text = array[3, 7].ToString();
            feld36.Text = array[3, 8].ToString();

            feld37.Text = array[4, 0].ToString();
            feld38.Text = array[4, 1].ToString();
            feld39.Text = array[4, 2].ToString();
            feld40.Text = array[4, 3].ToString();
            feld41.Text = array[4, 4].ToString();
            feld42.Text = array[4, 5].ToString();
            feld43.Text = array[4, 6].ToString();
            feld44.Text = array[4, 7].ToString();
            feld45.Text = array[4, 8].ToString();

            feld46.Text = array[5, 0].ToString();
            feld47.Text = array[5, 1].ToString();
            feld48.Text = array[5, 2].ToString();
            feld49.Text = array[5, 3].ToString();
            feld50.Text = array[5, 4].ToString();
            feld51.Text = array[5, 5].ToString();
            feld52.Text = array[5, 6].ToString();
            feld53.Text = array[5, 7].ToString();
            feld54.Text = array[5, 8].ToString();

            feld55.Text = array[6, 0].ToString();
            feld56.Text = array[6, 1].ToString();
            feld57.Text = array[6, 2].ToString();
            feld58.Text = array[6, 3].ToString();
            feld59.Text = array[6, 4].ToString();
            feld60.Text = array[6, 5].ToString();
            feld61.Text = array[6, 6].ToString();
            feld62.Text = array[6, 7].ToString();
            feld63.Text = array[6, 8].ToString();

            feld64.Text = array[7, 0].ToString();
            feld65.Text = array[7, 1].ToString();
            feld66.Text = array[7, 2].ToString();
            feld67.Text = array[7, 3].ToString();
            feld68.Text = array[7, 4].ToString();
            feld69.Text = array[7, 5].ToString();
            feld70.Text = array[7, 6].ToString();
            feld71.Text = array[7, 7].ToString();
            feld72.Text = array[7, 8].ToString();

            feld73.Text = array[8, 0].ToString();
            feld74.Text = array[8, 1].ToString();
            feld75.Text = array[8, 2].ToString();
            feld76.Text = array[8, 3].ToString();
            feld77.Text = array[8, 4].ToString();
            feld78.Text = array[8, 5].ToString();
            feld79.Text = array[8, 6].ToString();
            feld80.Text = array[8, 7].ToString();
            feld81.Text = array[8, 8].ToString();



        }


        public void GetInputToArray()
        {
            for(int x = 0; x < 9; x++)
            {
                for(int y = 0; y < 9; y++)
                {
                    felder[x, y] = new int();

                }
            }

            felder[0,0] = int.Parse(feld1.Text.ToString());
            felder[0,1] = int.Parse(feld2.Text.ToString());
            felder[0,2] = int.Parse(feld3.Text.ToString());
            felder[0,3] = int.Parse(feld4.Text.ToString());
            felder[0,4] = int.Parse(feld5.Text.ToString());
            felder[0,5] = int.Parse(feld6.Text.ToString());
            felder[0,6] = int.Parse(feld7.Text.ToString());
            felder[0,7] = int.Parse(feld8.Text.ToString());
            felder[0,8] = int.Parse(feld9.Text.ToString());

            felder[1, 0] = int.Parse(feld10.Text.ToString());
            felder[1, 1] = int.Parse(feld11.Text.ToString());
            felder[1, 2] = int.Parse(feld12.Text.ToString());
            felder[1, 3] = int.Parse(feld13.Text.ToString());
            felder[1, 4] = int.Parse(feld14.Text.ToString());
            felder[1, 5] = int.Parse(feld15.Text.ToString());
            felder[1, 6] = int.Parse(feld16.Text.ToString());
            felder[1, 7] = int.Parse(feld17.Text.ToString());
            felder[1, 8] = int.Parse(feld18.Text.ToString());

            felder[2, 0] = int.Parse(feld19.Text.ToString());
            felder[2, 1] = int.Parse(feld20.Text.ToString());
            felder[2, 2] = int.Parse(feld21.Text.ToString());
            felder[2, 3] = int.Parse(feld22.Text.ToString());
            felder[2, 4] = int.Parse(feld23.Text.ToString());
            felder[2, 5] = int.Parse(feld24.Text.ToString());
            felder[2, 6] = int.Parse(feld25.Text.ToString());
            felder[2, 7] = int.Parse(feld26.Text.ToString());
            felder[2, 8] = int.Parse(feld27.Text.ToString());

            felder[3, 0] = int.Parse(feld28.Text.ToString());
            felder[3, 1] = int.Parse(feld29.Text.ToString());
            felder[3, 2] = int.Parse(feld30.Text.ToString());
            felder[3, 3] = int.Parse(feld31.Text.ToString());
            felder[3, 4] = int.Parse(feld32.Text.ToString());
            felder[3, 5] = int.Parse(feld33.Text.ToString());
            felder[3, 6] = int.Parse(feld34.Text.ToString());
            felder[3, 7] = int.Parse(feld35.Text.ToString());
            felder[3, 8] = int.Parse(feld36.Text.ToString());


            felder[4, 0] = int.Parse(feld37.Text.ToString());
            felder[4, 1] = int.Parse(feld38.Text.ToString());
            felder[4, 2] = int.Parse(feld39.Text.ToString());
            felder[4, 3] = int.Parse(feld40.Text.ToString());
            felder[4, 4] = int.Parse(feld41.Text.ToString());
            felder[4, 5] = int.Parse(feld42.Text.ToString());
            felder[4, 6] = int.Parse(feld43.Text.ToString());
            felder[4, 7] = int.Parse(feld44.Text.ToString());
            felder[4, 8] = int.Parse(feld45.Text.ToString());

            felder[5, 0] = int.Parse(feld46.Text.ToString());
            felder[5, 1] = int.Parse(feld47.Text.ToString());
            felder[5, 2] = int.Parse(feld48.Text.ToString());
            felder[5, 3] = int.Parse(feld49.Text.ToString());
            felder[5, 4] = int.Parse(feld50.Text.ToString());
            felder[5, 5] = int.Parse(feld51.Text.ToString());
            felder[5, 6] = int.Parse(feld52.Text.ToString());
            felder[5, 7] = int.Parse(feld53.Text.ToString());
            felder[5, 8] = int.Parse(feld54.Text.ToString());

            felder[6, 0] = int.Parse(feld55.Text.ToString());
            felder[6, 1] = int.Parse(feld56.Text.ToString());
            felder[6, 2] = int.Parse(feld57.Text.ToString());
            felder[6, 3] = int.Parse(feld58.Text.ToString());
            felder[6, 4] = int.Parse(feld59.Text.ToString());
            felder[6, 5] = int.Parse(feld60.Text.ToString());
            felder[6, 6] = int.Parse(feld61.Text.ToString());
            felder[6, 7] = int.Parse(feld62.Text.ToString());
            felder[6, 8] = int.Parse(feld63.Text.ToString());

            felder[7, 0] = int.Parse(feld64.Text.ToString());
            felder[7, 1] = int.Parse(feld65.Text.ToString());
            felder[7, 2] = int.Parse(feld66.Text.ToString());
            felder[7, 3] = int.Parse(feld67.Text.ToString());
            felder[7, 4] = int.Parse(feld68.Text.ToString());
            felder[7, 5] = int.Parse(feld69.Text.ToString());
            felder[7, 6] = int.Parse(feld70.Text.ToString());
            felder[7, 7] = int.Parse(feld71.Text.ToString());
            felder[7, 8] = int.Parse(feld72.Text.ToString());

            felder[8, 0] = int.Parse(feld73.Text.ToString());
            felder[8, 1] = int.Parse(feld74.Text.ToString());
            felder[8, 2] = int.Parse(feld75.Text.ToString());
            felder[8, 3] = int.Parse(feld76.Text.ToString());
            felder[8, 4] = int.Parse(feld77.Text.ToString());
            felder[8, 5] = int.Parse(feld78.Text.ToString());
            felder[8, 6] = int.Parse(feld79.Text.ToString());
            felder[8, 7] = int.Parse(feld80.Text.ToString());
            felder[8, 8] = int.Parse(feld81.Text.ToString());



        }
    }
}
