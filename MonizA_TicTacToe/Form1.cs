using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonizA_TicTacToe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            //create a random number
            Random rand = new Random();

            //create the two-dimensional array
            const int Rows = 3;
            const int Cols = 3;
            int[,] values = new int[Rows, Cols];

            //Fill the array with Random numbers

            for (int row = 0; row < Rows; row++)
            {
                for(int col = 0; col < Cols; col++)
                {
                    values[row, col] = rand.Next(2);
                }
            }

            //variables to hold win results
            int Xwins, Owins;

            //display the random results
            DisplayResults(values);

            //collect the results in the variables
            Owins = WinnerO(values);
            Xwins = WinnerX(values);

            //display winner
            if (Owins > Xwins)
                winLabel.Text = ("Player O is the winner!");
            else if (Xwins > Owins)
                winLabel.Text = ("Player X is the winner!");
            else
                winLabel.Text = ("Player O and Player X tied");
        }

        //function to display results on form
        private void DisplayResults(int[,] results)
        {
            //get each label and display "X" or "O" depending on the value
            //label1
            if (results[0, 0] == 0)
                label1.Text = ("O");
            else
                label1.Text = ("X");
            //lable2
            if (results[0, 1] == 0)
                label2.Text = ("O");
            else
                label2.Text = ("X");
            //label3
            if (results[0, 2] == 0)
                label3.Text = ("O");
            else
                label3.Text = ("X");
            //label4
            if (results[1, 0] == 0)
                label4.Text = ("O");
            else
                label4.Text = ("X");
            //label5
            if (results[1, 1] == 0)
                label5.Text = ("O");
            else
                label5.Text = ("X");
            //label6
            if (results[1, 2] == 0)
                label6.Text = ("O");
            else
                label6.Text = ("X");
            //label7
            if (results[2, 0] == 0)
                label7.Text = ("O");
            else
                label7.Text = ("X");
            //label8
            if (results[2, 1] == 0)
                label8.Text = ("O");
            else
                label8.Text = ("X");
            //label9
            if (results[2, 2] == 0)
                label9.Text = ("O");
            else
                label9.Text = ("X");
        }

        //this function will determine if the Player "O" won any rows, columns or diagonals
        private int WinnerO(int [,] results)
        {
            const int Rows = 3, Cols = 3; //to use in loop
            int Owins = 0; //to hold value to return
            int total; //accumulator to sum rows, columns and diagonals to test if there are 3 in a row

            //get the sum of the rows, if the sum is 0, then "O" wins that row
            for (int row = 0; row < Rows; row++)
            {
                //set the accumulator to 0
                total = 0;
                //total the row
                for (int col = 0; col < Cols; col++)
                    total += results[row, col];

                //add to Owins if results equal 0
                if (total == 0)
                    Owins++;
            }

            //get the sum of the columns, of the sum is 0, then "O" wins that column
            for (int col = 0; col < Cols; col++)
            {
                //set accumulator to 0
                total = 0;
                //total the column
                for (int row = 0; row < Rows; row++)
                    total += results[row, col];

                //add to Owins if results equal 0
                if (total == 0)
                    Owins++;
            }

            //test the diagonals for a win
            if (results[0, 0] + results[1, 1] + results[2, 2] == 0)
                Owins++;
            if (results[0, 2] + results[1, 1] + results[2, 0] == 0)
                Owins++;
            //return Owins
            return Owins;
        }

        //this function will determine if the Player "X" won any rows, columns or diagonals
        private int WinnerX(int[,] results)
        {
            const int Rows = 3, Cols = 3; //to use in loop
            int Xwins = 0; //to hold value to return
            int total; //accumulator to sum rows, columns and diagonals to test if there are 3 in a row

            //get the sum of the rows, if the sum is 3, then "X" wins that row
            for (int row = 0; row < Rows; row++)
            {
                //set the accumulator to 0
                total = 0;
                //total the row
                for (int col = 0; col < Cols; col++)
                    total += results[row, col];

                //add to Xwins if results equal 3
                if (total == 3)
                    Xwins++;
            }

            //get the sum of the columns, of the sum is 3, then "X" wins that column
            for (int col = 0; col < Cols; col++)
            {
                //set accumulator to 0
                total = 0;
                //total the column
                for (int row = 0; row < Rows; row++)
                    total += results[row, col];

                //add to Xwins if results equal 3
                if (total == 3)
                    Xwins++;
            }

            //test the diagonals for a win
            if (results[0, 0] + results[1, 1] + results[2, 2] == 3)
                Xwins++;
            if (results[0, 2] + results[1, 1] + results[2, 0] == 3)
                Xwins++;
            //return Xwins
            return Xwins;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //close form
            this.Close();
        }
    }
}
