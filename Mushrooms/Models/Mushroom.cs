using System;

namespace Mushrooms.Models
{
    internal class Mushroom
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

        internal Guid Id { get; private set; }
        internal string CommonName { get; private set; }
        internal string ScientificName { get; private set; }
        internal Cap Cap { get; private set; }
        internal MarginType MarginType { get; private set; }
        internal MarginCurvature MarginCurvature { get; private set; }
        internal GillAttachment GillAttachment { get; private set; }
        internal StemShape StemShape { get; private set; }
        internal RingType RingType { get; private set; }
    }
}