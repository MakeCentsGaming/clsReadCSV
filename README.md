# clsReadCSV
Read a csv into an object


class that will read a csv into an object, even if that csv has quotes or commas in a field

this object includes:
      public List<string> header { set; get; }
      public List<clsCSVLine> lines { set; get; }
      public string fileName { set; get; }
      public bool hasheader { set; get; }
  
the clsCSVLine includes:
      public List<string> header { set; get; }
      public bool hasheader { set; get; }
      public List<string> fields { set; get; }
      public string line { set; get; }
