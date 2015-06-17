using System.Collections.Generic;

namespace SPU.Lib.FraudDetection.MailMasterRenders
{
    public class PlaceHolderFinder : IPlaceHolderFinder
    {
        public ITagFinder OpenTagFinder { get; set; }

        public ITagFinder CloseTagFinder { get; set; }

        public PlaceHolderFinder()
        {
            OpenTagFinder = new TagFinder
            {
                Tag = "<placeholder>"
            };

            CloseTagFinder = new TagFinder
            {
                Tag = "</placeholder>"
            };
        }

        public IList<PlaceholderPosition> GetPlaceHolderPositions(string content)
        {
            var locations = new List<PlaceholderPosition>();
            var openPositions = OpenTagFinder.GetTagPositions(content);
            var closePositions = CloseTagFinder.GetTagPositions(content);

            if (openPositions.Count == 0 || closePositions.Count == 0)
            {
                return locations;
            }

            for (int i = 0; i < openPositions.Count && i < closePositions.Count; i++)
            {
                locations.Add(new PlaceholderPosition
                {
                    StartPlaceholder = openPositions[i],
                    EndPlaceholder = closePositions[i]
                });
            }

            return locations;
        }
    }
}