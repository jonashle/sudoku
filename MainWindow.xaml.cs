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
        private List<TextBox> myTextboxList = new List<TextBox>();
        int gamble;
        public MainWindow()
        {
            InitializeComponent();
            initializeTextBoxes();
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            foreach(TextBox t in myTextboxList)
            {
                t.Text = "0";
            }
        }

        private void LoadBtn_Click(object sender, RoutedEventArgs e)
        {

            feld1.Text = "0";
            feld2.Text = "0";
            feld3.Text = "0";
            feld4.Text = "0";
            feld5.Text = "5";
            feld6.Text = "1";
            feld7.Text = "0";
            feld8.Text = "0";
            feld9.Text = "0";
            feld10.Text = "0";
            feld11.Text = "7";
            feld12.Text = "0";
            feld13.Text = "0";
            feld14.Text = "0";
            feld15.Text = "0";
            feld16.Text = "3";
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
            feld28.Text = "1";
            feld29.Text = "0";
            feld30.Text = "0";
            feld31.Text = "0";
            feld32.Text = "4";
            feld33.Text = "0";
            feld34.Text = "0";
            feld35.Text = "6";
            feld36.Text = "0";
            feld37.Text = "0";
            feld38.Text = "3";
            feld39.Text = "0";
            feld40.Text = "2";
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
            feld53.Text = "5";
            feld54.Text = "4";
            feld55.Text = "5";
            feld56.Text = "0";
            feld57.Text = "1";
            feld58.Text = "0";
            feld59.Text = "0";
            feld60.Text = "0";
            feld61.Text = "0";
            feld62.Text = "0";
            feld63.Text = "0";
            feld64.Text = "0";
            feld65.Text = "0";
            feld66.Text = "0";
            feld67.Text = "7";
            feld68.Text = "0";
            feld69.Text = "0";
            feld70.Text = "8";
            feld71.Text = "0";
            feld72.Text = "0";
            feld73.Text = "4";
            feld74.Text = "6";
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
            List<int[]> ZweiOptionen = new List<int[]>();
            int aenderungen = 0;
            for(int x=0; x < 9; x++)
            {
                for(int y=0; y<9; y++)
                {
                    
                    if (felder[x, y] == 0)
                    {
                        FillList(); //Liste mit 1 bis 9 füllen

                        //horizontal
                        for(int yw = 0; yw < 9; yw++)
                        {
                            if (list.Contains(felder[x, yw]))
                            {
                                list.Remove(felder[x, yw]);
                            }
                        }

                        //vertikal
                        for (int xw = 0; xw < 9; xw++)
                        {
                            if (list.Contains(felder[xw, y]))
                            {
                                list.Remove(felder[xw, y]);
                            }
                        }


                        int xBoarderSouth=0,xBoarderNorth=0;
                        int yBoarderSouth=0, yBoarderNorth=0;
                        //passende Kästchen finden
                        switch (x)
                        {   case 0:
                            case 1:
                            case 2: xBoarderSouth = 0;
                                    xBoarderNorth = 2;
                                    break;
                            case 3:
                            case 4:
                            case 5: xBoarderSouth = 3; xBoarderNorth = 5;
                                break;
                            case 6:
                            case 7:
                            case 8:
                                xBoarderSouth = 6; xBoarderNorth = 8;
                                break;
                        }
                        switch (y)
                        {
                            case 0:
                            case 1:
                            case 2:
                                yBoarderSouth = 0;
                                yBoarderNorth = 2;
                                break;
                            case 3:
                            case 4:
                            case 5:
                                yBoarderSouth = 3; yBoarderNorth = 5;
                                break;
                            case 6:
                            case 7:
                            case 8:
                                yBoarderSouth = 6; yBoarderNorth = 8;
                                break;
                        }
                      
                            for (int i = xBoarderSouth; i <= xBoarderNorth; i++)
                            {
                                for (int j = yBoarderSouth; j <= yBoarderNorth; j++)
                                {
                                    if (list.Contains(felder[i, j]))
                                    {
                                        list.Remove(felder[i, j]);
                                    }
                                    
                                }
                            }
                        
                        if (list.Count == 1)
                        {
                            felder[x, y] = list.ElementAt(0);
                            aenderungen++;
                        }
                        if (list.Count == 2)
                        {
                            int[] array = new int[4];
                            array[0] = x;
                            array[1] = y;
                            array[2] = list.First();
                            array[3] = list.Last();
                            ZweiOptionen.Add(array);
                        }
                    }
                }
            }
            /*
            if (aenderungen == 0 && ZweiOptionen.Count!=0)
            {
    
                gambling(ZweiOptionen.First()[0], ZweiOptionen.First()[1], ZweiOptionen.First()[2], ZweiOptionen.First()[3]);
            }*/
        }
        /*
        public void gambling(int x,int y,int a, int b)
        {
             int[,] sicherung = new int[9, 9];
            sicherung = felder;

            //erster Versuch
            felder[x, y] = a;
            for (int i = 0; i < 400; i++)
            {
                CheckZahl();

                if (CheckFertig())
                {
                    return;
                }

            }
            //erster Versuch nicht erfolgreich
            felder = sicherung;
            felder[x, y] = b;
            for (int i = 0; i < 400; i++)
            {
                CheckZahl();

                if (CheckFertig())
                {
                    return;
                }

            }
            felder = sicherung;
        }
        */

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
            }

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
            for(int x = 0; x < 9; x++)
            {
                for(int y=0;y < 9; y++)
                {
                    myTextboxList.ElementAt(x * 9 + y).Text = array[x, y].ToString();
                }
            }

        }


        public void GetInputToArray()
        {
            for(int x = 0; x < 9; x++)
            {
                for(int y = 0; y < 9; y++)
                {
                    felder[x, y] = new int();
                    felder[x, y] = int.Parse(myTextboxList.ElementAt(x * 9 + y).Text.ToString());
                }
            }

        }
        public void initializeTextBoxes()
        {
            myTextboxList.Add(feld1);
            myTextboxList.Add(feld2);
            myTextboxList.Add(feld3);
            myTextboxList.Add(feld4);
            myTextboxList.Add(feld5);
            myTextboxList.Add(feld6);
            myTextboxList.Add(feld7);
            myTextboxList.Add(feld8);
            myTextboxList.Add(feld9);
            myTextboxList.Add(feld10);
            myTextboxList.Add(feld11);
            myTextboxList.Add(feld12);
            myTextboxList.Add(feld13);
            myTextboxList.Add(feld14);
            myTextboxList.Add(feld15);
            myTextboxList.Add(feld16);
            myTextboxList.Add(feld17);
            myTextboxList.Add(feld18);
            myTextboxList.Add(feld19);
            myTextboxList.Add(feld20);
            myTextboxList.Add(feld21);
            myTextboxList.Add(feld22);
            myTextboxList.Add(feld23);
            myTextboxList.Add(feld24);
            myTextboxList.Add(feld25);
            myTextboxList.Add(feld26);
            myTextboxList.Add(feld27);
            myTextboxList.Add(feld28);
            myTextboxList.Add(feld29);
            myTextboxList.Add(feld30);
            myTextboxList.Add(feld31);
            myTextboxList.Add(feld32);
            myTextboxList.Add(feld33);
            myTextboxList.Add(feld34);
            myTextboxList.Add(feld35);
            myTextboxList.Add(feld36);
            myTextboxList.Add(feld37);
            myTextboxList.Add(feld38);
            myTextboxList.Add(feld39);
            myTextboxList.Add(feld40);
            myTextboxList.Add(feld41);
            myTextboxList.Add(feld42);
            myTextboxList.Add(feld43);
            myTextboxList.Add(feld44);
            myTextboxList.Add(feld45);
            myTextboxList.Add(feld46);
            myTextboxList.Add(feld47);
            myTextboxList.Add(feld48);
            myTextboxList.Add(feld49);
            myTextboxList.Add(feld50);
            myTextboxList.Add(feld51);
            myTextboxList.Add(feld52);
            myTextboxList.Add(feld53);
            myTextboxList.Add(feld54);
            myTextboxList.Add(feld55);
            myTextboxList.Add(feld56);
            myTextboxList.Add(feld57);
            myTextboxList.Add(feld58);
            myTextboxList.Add(feld59);
            myTextboxList.Add(feld60);
            myTextboxList.Add(feld61);
            myTextboxList.Add(feld62);
            myTextboxList.Add(feld63);
            myTextboxList.Add(feld64);
            myTextboxList.Add(feld65);
            myTextboxList.Add(feld66);
            myTextboxList.Add(feld67);
            myTextboxList.Add(feld68);
            myTextboxList.Add(feld69);
            myTextboxList.Add(feld70);
            myTextboxList.Add(feld71);
            myTextboxList.Add(feld72);
            myTextboxList.Add(feld73);
            myTextboxList.Add(feld74);
            myTextboxList.Add(feld75);
            myTextboxList.Add(feld76);
            myTextboxList.Add(feld77);
            myTextboxList.Add(feld78);
            myTextboxList.Add(feld79);
            myTextboxList.Add(feld80);
            myTextboxList.Add(feld81);
        }
    }

    
}
