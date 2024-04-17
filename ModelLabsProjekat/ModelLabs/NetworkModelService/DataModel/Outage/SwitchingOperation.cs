using FTN.Common;
using FTN.Services.NetworkModelService.DataModel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTN.Services.NetworkModelService.DataModel.Outage
{
    public class SwitchingOperation : IdentifiedObject
    {
        public SwitchingOperation(long globalId) : base(globalId)
        {
        }

        public SwichState NewState { get; set; }
        public DateTime OperationTime { get; set; }
        public long OutageSchedule { get; set; } = 0;

        public override bool Equals(object obj)
        {
            if (base.Equals(obj))
            {
                SwitchingOperation so = (SwitchingOperation)obj;
                return ((so.OutageSchedule == this.OutageSchedule) && (so.OperationTime == this.OperationTime) &&(so.NewState == this.NewState));
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
                case ModelCode.SWITCHINGOPERATION_NEWSTATE:
                case ModelCode.SWITCHINGOPERATION_OPERATIONTIME:
                case ModelCode.SWITCHINGOPERATION_OUTAGESCHEDULE:
                    return true;

                default:
                    return base.HasProperty(property);
            }
        }

        public override void GetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.SWITCHINGOPERATION_NEWSTATE:
                    property.SetValue((short)NewState);
                    break;
                case ModelCode.SWITCHINGOPERATION_OPERATIONTIME:
                    property.SetValue(OperationTime);
                    break;
                case ModelCode.SWITCHINGOPERATION_OUTAGESCHEDULE:
                    property.SetValue(OutageSchedule);
                    break;

                default:
                    base.GetProperty(property);
                    break;
            }
        }

        public override void SetProperty(Property property)
        {
            switch (property.Id)
            {
                case ModelCode.SWITCHINGOPERATION_NEWSTATE:
                    NewState = (SwichState)property.AsEnum();
                    break;
                case ModelCode.SWITCHINGOPERATION_OPERATIONTIME:
                    OperationTime = property.AsDateTime();
                    break;
                case ModelCode.SWITCHINGOPERATION_OUTAGESCHEDULE:
                    OutageSchedule = property.AsReference();
                    break;
                


                default:
                    base.SetProperty(property);
                    break;
            }
        }

        #endregion IAccess implementation

    }
}
