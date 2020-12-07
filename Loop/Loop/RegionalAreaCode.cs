using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Loop
{
    public class RegionalAreaCode
    {
        //matching UK formatting rules
        public string MatchUKAreaCode(string phoneNumber)
        {
            string phoneNumberResult = phoneNumber;
            try
            {
                List<Regex> regexBritishNumbers = new List<Regex>
            {
                new Regex(@"\+447\d{3}(\s)?\d{5}\b"),               //01### #####
                new Regex(@"\+441\d{3}(\s)?\d{6}\b"),               //01### ######
                new Regex(@"\+4411\d{1}(\s)?\d{3}(\s)?\d{4}\b"),    //011# ### ####
                new Regex(@"\+441\d{1}1(\s)?\d{3}(\s)?\d{4}\b"),    //01#1 ### ####
                new Regex(@"\+4413397(\s)?\d{5}\b"),                //013397 #####
                new Regex(@"\+4413398(\s)?\d{5}\b"),                //013398 #####
                new Regex(@"\+4413873(\s)?\d{5}\b"),                //013873 #####
                new Regex(@"\+4415242(\s)?\d{5}\b"),                //015242 #####
                new Regex(@"\+4415394(\s)?\d{5}\b"),                //015394 #####
                new Regex(@"\+4415395(\s)?\d{5}\b"),                //015395 #####
                new Regex(@"\+4415396(\s)?\d{5}\b"),                //015396 #####
                new Regex(@"\+4416973(\s)?\d{5}\b"),                //016973 #####
                new Regex(@"\+4416974(\s)?\d{5}\b"),                //016974 #####
                new Regex(@"\+4416977(\s)?\d{4}\b"),                //016977 ####
                new Regex(@"\+4416977(\s)?\d{5}\b"),                //016977 #####
                new Regex(@"\+4417683(\s)?\d{5}\b"),                //017683 #####
                new Regex(@"\+4417684(\s)?\d{5}\b"),                //017684 #####
                new Regex(@"\+4417687(\s)?\d{5}\b"),                //017687 #####
                new Regex(@"\+4419467(\s)?\d{5}\b"),                //019467 #####
                new Regex(@"\+4419755(\s)?\d{5}\b"),                //019755 #####
                new Regex(@"\+4419756(\s)?\d{5}\b"),                //019756 #####
                new Regex(@"\+442\d{1}(\s)?\d{4}(\s)?\d{4}\b"),     //02# #### ####
                new Regex(@"\+443\d{2}(\s)?\d{3}(\s)?\d{4}\b"),     //03## ### ####
                new Regex(@"\+445\d{3}(\s)?\d{6}\b"),               //05### ######
                new Regex(@"\+447\d{3}(\s)?\d{6}\b"),               //07### ######
                new Regex(@"\+44800(\s)?\d{6}\b"),                  //0800 ######
                new Regex(@"\+448\d{2}(\s)?\d{3}(\s)?\d{4}\b"),     //08## ### ####
                new Regex(@"\+449\d{2}(\s)?\d{3}(\s)?\d{4}\b")      //09## ### ####
            };

                foreach (Regex numberMatch in regexBritishNumbers)
                {
                    if (numberMatch.IsMatch(phoneNumber))
                    {
                        phoneNumberResult = ConvertToReadable(numberMatch.ToString(), phoneNumber);
                    }
                }
            } catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return phoneNumberResult;
        }

        //Convert to human readable

        private string ConvertToReadable(string regexValue, string phoneNumber)
        {
            string result = phoneNumber;

            try
            {
                if (phoneNumber.StartsWith("+44"))
                {
                    result = AddWhiteSpace(regexValue, phoneNumber);
                    result = Regex.Replace(result, @"\+44", @"0");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return result;
        }

        //Adds white space to phone number if needed

        private string AddWhiteSpace(string regexValue, string phoneNumber)
        {
            string result = phoneNumber;
            try
            {
                if (!phoneNumber.Contains(" "))
                {
                    if (regexValue == "\\+447\\d{3}(\\s)?\\d{5}\\b" ||
                        regexValue == "\\+441\\d{3}(\\s)?\\d{6}\\b" ||
                        regexValue == "\\+445\\d{3}(\\s)?\\d{6}\\b" ||
                        regexValue == "\\+447\\d{3}(\\s)?\\d{6}\\b")
                    {
                        result = phoneNumber.Insert(7, " ");
                    }
                    else if (regexValue == "\\+4411\\d{1}(\\s)?\\d{3}(\\s)?\\d{4}\\b" ||
                        regexValue == "\\+441\\d{1}1(\\s)?\\d{3}(\\s)?\\d{4}\\b" ||
                        regexValue == "\\+441\\d{1}1(\\s)?\\d{3}(\\s)?\\d{4}\\b" ||
                        regexValue == "\\+443\\d{2}(\\s)?\\d{3}(\\s)?\\d{4}\\b" ||
                        regexValue == "\\+448\\d{2}(\\s)?\\d{3}(\\s)?\\d{4}\\b" ||
                        regexValue == "\\+449\\d{2}(\\s)?\\d{3}(\\s)?\\d{4}\\b")
                    {
                        result = phoneNumber.Insert(6, " ");
                        result = result.Insert(10, " ");
                    }
                    else if (regexValue == "\\+442\\d{1}(\\s)?\\d{4}(\\s)?\\d{4}\\b")
                    {
                        result = phoneNumber.Insert(5, " ");
                        result = result.Insert(10, " ");
                    }
                    else if (regexValue == "\\+44800(\\s)?\\d{6}\\b")
                    {
                        result = phoneNumber.Insert(6, " ");
                    }
                    else
                    {
                        result = phoneNumber.Insert(8, " ");
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return result;
        }
    }
}
