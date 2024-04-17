using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Wires
{
    public class Switch : ConductingEquipment
    {
        public Switch(long globalId) : base(globalId)
        {
        }
        public bool NormalOpen { get; set; }
        public bool Retained { get; set; }
        public int SwitchOnCount { get; set; }
        public DateTime SwitchOnDate { get; set; }


        public override bool Equals(object x)
        {
            if (base.Equals(x))
            {
                Switch s = (Switch)x;
                return ((s.NormalOpen == this.NormalOpen) && (s.Retained == this.Retained) && (s.SwitchOnCount == this.SwitchOnCount) && (s.SwitchOnDate == this.SwitchOnDate));
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #region IAccess implementation

        public override bool HasProperty(ModelCode property)
        {
            switch (property)
            {
                case ModelCode.SWITCH_NORMALOPEN:
                case ModelCode.SWITCH_RETAINED:
                case ModelCode.SWITCH_SWITCHONCOUNT:
                case ModelCode.SWITCH_SWITCHONDATE:
                    return true;

                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property prop)
        {
            switch(prop.Id)
            {
                case ModelCode.SWITCH_NORMALOPEN:
                    prop.SetValue(NormalOpen);
                    break;
                case ModelCode.SWITCH_RETAINED:
                    prop.SetValue(Retained);
                    break;
                case ModelCode.SWITCH_SWITCHONCOUNT:
                    prop.SetValue(SwitchOnCount);
                    break;
                case ModelCode.SWITCH_SWITCHONDATE:
                    prop.SetValue(SwitchOnDate);
                    break;

                default:
                    base.GetProperty(prop);
                    break;
            }
        }

        public override void SetProperty(Property property)
        {
            switch(property.Id)
            {
                case ModelCode.SWITCH_NORMALOPEN:
                    NormalOpen = property.AsBool();
                    break;
                case ModelCode.SWITCH_RETAINED:
                    Retained = property.AsBool();
                    break;
                case ModelCode.SWITCH_SWITCHONCOUNT:
                    SwitchOnCount = property.AsInt();
                    break;
                case ModelCode.SWITCH_SWITCHONDATE:
                    SwitchOnDate = property.AsDateTime();
                    break;

                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation

        #region IReference implementation

        public override void GetReferences(Dictionary<ModelCode, List<long>> references, TypeOfReference refType)
        {
            base.GetReferences(references, refType);
        }

        #endregion IReference implementation
    }
}
