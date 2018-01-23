using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Replace_Tag_Inner_Text
{
   /// <summary>
   /// class to store a list of clsCSVLine objects and other csv data
   /// </summary>
    class clsReadCSV
    {
      public List<string> header { set; get; }
      public List<clsCSVLine> lines { set; get; }
      public string fileName { set; get; }
      public bool hasheader { set; get; }
      public clsReadCSV(string file, bool hasheader = false)
      {
         this.header = new List<string>();
         this.lines = new List<clsCSVLine>();
         this.fileName = file;
         this.hasheader = hasheader;
         ReadCSV();
      }
      /// <summary>
      /// Read the csv and populate the clsCSVLine objects
      /// </summary>
      public void ReadCSV()
      {
         string[] fields;
         string[] nlines;
         TextFieldParser parser;
         clsCSVLine clscsvline;
         bool headerline;
         
         if (!File.Exists(fileName))
         {            
            return;
         }
         
         nlines = File.ReadAllLines(this.fileName);
         headerline = this.hasheader;
         foreach (string csvline in nlines)
         {
            //There is no point in reading empty lines
            if (csvline.Trim() == "") continue;
            
            clscsvline = new clsCSVLine();
            clscsvline.line = csvline;
            parser = new TextFieldParser(new StringReader(csvline));
            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(",");
            while (!parser.EndOfData)
            {
               fields = parser.ReadFields();
               foreach (string field in fields)
               {
                  //if csv has headers read first line as header, set first line to false
                  if (headerline)
                  {
                     this.header.Add(field);
                     clscsvline.header.Add(field);
                  }
                  else
                  {
                     clscsvline.header = this.header;
                     clscsvline.hasheader = this.hasheader;
                     //else read as regular line
                     clscsvline.fields.Add(field);
                  }
               }
               if(headerline)
               {
                  headerline = false;
               }
               this.lines.Add(clscsvline);
            }
            parser.Close();
         }
      }
   }

   /// <summary>
   /// class to store csv line data
   /// </summary>
   public class clsCSVLine
   {
      public List<string> header { set; get; }
      public bool hasheader { set; get; }
      public List<string> fields { set; get; }
      public string line { set; get; }

      public clsCSVLine()
      {
         header = new List<string>();
         fields = new List<string>();
      }
   }
}
