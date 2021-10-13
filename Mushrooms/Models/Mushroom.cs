using System;
using SQLite;

namespace Mushrooms.Models
{
  public class Mushroom
  {
    public Mushroom()
    {
      
    }

    public Mushroom(int id, string commonName, string scientificName, Cap cap, MarginType marginType,
        MarginCurvature marginCurvature, GillAttachment gillAttachment, StemShape stemShape, RingType ringType)
    {
      Id = id;
      CommonName = commonName;
      ScientificName = scientificName;
      Cap = cap;
      MarginType = marginType;
      MarginCurvature = marginCurvature;
      GillAttachment = gillAttachment;
      StemShape = stemShape;
      RingType = ringType;
    }

    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string CommonName { get;  set; }
    public string ScientificName { get; set; }
    public Cap Cap { get; set; }
    public MarginType MarginType { get; set; }
    public MarginCurvature MarginCurvature { get; set; }
    public GillAttachment GillAttachment { get; set; }
    public StemShape StemShape { get; set; }
    public RingType RingType { get; set; }
  }
}