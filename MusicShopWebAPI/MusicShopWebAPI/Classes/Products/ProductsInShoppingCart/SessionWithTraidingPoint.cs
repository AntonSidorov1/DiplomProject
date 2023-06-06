using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicShopWebAPI
{
    public class SessionWithTraidingPoint : ProductsQuantitiesSession
    {
        int pointID = 0;
        public int PointID
        {
            get => pointID;
            set => pointID = value;
        }

        string pointType = "all";

        public string PointType
        {
            get => pointType;
            set => pointType = value;
        }

        public PounktType GetPounktType()
        {

            if (PointType.Trim().ToLower() == ("shop").Trim().ToLower())
                return PounktType.Shop;
            if (PointType.Trim().ToLower() == ("stock").Trim().ToLower())
                return PounktType.Stock;
            return PounktType.All;

        }

        public void SetPounktType(PounktType pounkt)
        {
            PointType = pounkt.ToString();
        }

    }
}
