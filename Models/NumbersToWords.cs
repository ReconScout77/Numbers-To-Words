using System;
using System.Collections.Generic;

namespace NumbersToWords.Models
{
    public class NumberToWord
    {
      private int _number;
      private string _numberWord;
    //   Dictionary<int, string[]> _denominationDictionary = new Dictionary<int, string[]>()
    //   {
    //       { 0, new string [] {"zero","one","two","three","four","five","six","seven","eight","nine"}},
    //       { 1, new string [] {"ten","twenty","thirty","forty","fifty","sixty","seventy","eighty","ninety"}},
    //         {2, new string []{"hundred"}},
    //         {3, new string []{"thousand"}},
    //         {6, new string []{"million"}},
    //         {9, new string []{"billion"}},
    //         {12, new string []{"trillion"}}
    //   };
    Dictionary<int, string> ones = new Dictionary<int, string>() 
      {
          {1, "one"},
          {2, "two"},
          {3, "three"},
          {4, "four"},
          {5, "five"},
          {6, "six"},
          {7, "seven"},
          {8, "eight"},
          {9, "nine"},
      };

      Dictionary<int, string> tens = new Dictionary<int, string>()
      {
          {0, "ten"},
          {1, "eleven"},
          {2, "twelve"},
          {3, "thirteen"},
          {4, "forteen"},
          {5, "fifteen"},
          {6, "sixteen"},
          {7, "seventeen"},
          {8, "eighteen"},
          {9, "nineteen"},
      };

      Dictionary<int, string> doubleDigits = new Dictionary<int, string>()
      {
          {2, "twenty"},
          {3, "thirty"},
          {4, "forty"},
          {5, "fifty"},
          {6, "sixty"},
          {7, "seventy"},
          {8, "eighty"},
          {9, "ninety"},
      };

      public NumberToWord(int number)
      {
          _number = number;
      }
      public string GetNumberWord()
      {
          return _numberWord;
      }

      public string GetOnes(char[] numArr, int index)
      {
          return ones[int.Parse(numArr[numArr.Length - index].ToString())];
      }
      public string GetTens(char[] numArr, int index)
      {
        return tens[int.Parse(numArr[numArr.Length - (index-1)].ToString())];
      }
      public bool FigureTensException(char[] numArr, int index)
      {
          string potentialTen = "";
          potentialTen += numArr[numArr.Length - (index)].ToString();
          potentialTen += numArr[numArr.Length - (index-1)].ToString();
          Console.WriteLine(potentialTen);
          int toNumber = int.Parse(potentialTen);
          Console.WriteLine(toNumber);
          Console.WriteLine(toNumber < 20 && toNumber > 9);
          return (toNumber < 20 && toNumber > 9);
      }
      public string GetDoubleDigits(char[] numArr, int index)
      {
          return doubleDigits[int.Parse(numArr[numArr.Length - index].ToString())];
      }
      public string GetHundreds(char[] numArr, int index)
      {
          return ones[int.Parse(numArr[numArr.Length - index].ToString())];
      }
       public string GetThousands(char[] numArr, int index)
      {
          return ones[int.Parse(numArr[numArr.Length - index].ToString())];
      }
       public string GetTenThousands(char[] numArr, int index)
      {
          return doubleDigits[int.Parse(numArr[numArr.Length - index].ToString())];
      }
       public string GetHundredThousands(char[] numArr, int index)
      {
          return ones[int.Parse(numArr[numArr.Length - index].ToString())];
      }
       public string GetMillions(char[] numArr, int index)
      {
          return ones[int.Parse(numArr[numArr.Length - index].ToString())];
      }

      public string ConvertNumberToWord()
      {
          char [] numberArr = _number.ToString().ToCharArray();
          string result = "";
          int numberLength = numberArr.Length;
          string oneth = "";
          string tenth = "";
          string hundredth = "";
          
          

          if(_number == 0)
          {
              return "zero";
          }
          else
          {
            for(int j = numberLength; j>0; j--)
            {
                if(j == 7)
                {
                    result += this.GetOnes(numberArr, j) + " million ";
                }
                else if(j == 6)
                {
                    result += this.GetOnes(numberArr, j) + " hundred ";
                }
                else if(j == 5)
                {
                    if(this.FigureTensException(numberArr, j))
                    {
                        result += this.GetTens(numberArr, j) + " thousand ";
                        j--;
                    }
                    else
                    {
                        result += this.GetDoubleDigits(numberArr, j);
                    }
                }
                else if(j == 4)
                {
                    result += this.GetOnes(numberArr, j) + " thousand ";
                }
                else if(j == 3)
                {
                    result += this.GetOnes(numberArr, j) + " hundred ";
                }
                else if(j == 2)
                {
                    if(this.FigureTensException(numberArr, j))
                    {
                       return result += this.GetTens(numberArr, j);
                    }
                    else
                    {
                         result += this.GetDoubleDigits(numberArr, j);
                    }
                } 
                else if(j == 1)
                {
                    result += " " + this.GetOnes(numberArr, j);
                }
            }
            result += hundredth + tenth  + " " + oneth;
            //   for(int i = 0; i < numberLength; i++)
            //   {
            //     if (numberLength%3 == 2) 
            //      {
            //          result += doubleDigits[int.Parse(numberArr[i].ToString())];
            //      } 
            //      else
            //      {
            //          result += ones[int.Parse(numberArr[i].ToString())];
            //      }
                //  else
                //  {
                //     result += hundreds[int.Parse(numberArr[i].ToString())];
                //  }
              //}
          }
        //   for (int i = 0; i< 10; i++)
        //   {
        //     if(_number == i)
        //     {
        //         string [] ones = _denominationDictionary[i];
        //         result = ones[i+1];
        //     }
        //   }

          return result.Trim();
      }
    }
}