using System.Collections.Generic;

namespace Platformer
{
    public class EndLevelPortalsControllerModel
    {
        public EndLevelPortalView CurrentEndLevelPortal;
        private List<EndLevelPortalView> _endLevelPortalViews;

        public List<EndLevelPortalView> EndLevelPortalViews { get => _endLevelPortalViews; }

        public EndLevelPortalsControllerModel(EndLevelPortalsProtoModel levelManagerProtoModel)
        {
            _endLevelPortalViews = new List<EndLevelPortalView>(levelManagerProtoModel.EndLevelPortalViews);

            CurrentEndLevelPortal = _endLevelPortalViews[0].SetInstanceID();
        }
    }
}