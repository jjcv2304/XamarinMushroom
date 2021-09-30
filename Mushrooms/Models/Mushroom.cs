using System;

namespace Mushrooms.Models
{
    public class Mushroom
    {
        public Mushroom(Guid id, string commonName, string scientificName, Cap cap, MarginType marginType,
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

        public Guid Id { get; private set; }
        public string CommonName { get; private set; }
        public string ScientificName { get; private set; }
        public Cap Cap { get; private set; }
        public MarginType MarginType { get; private set; }
        public MarginCurvature MarginCurvature { get; private set; }
        public GillAttachment GillAttachment { get; private set; }
        public StemShape StemShape { get; private set; }
        public RingType RingType { get; private set; }
    }
}