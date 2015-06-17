using System.Collections.Generic;
using System.Text;

namespace SPU.Lib.FraudDetection.MailMasterRenders
{
    public interface IPlaceHolderFinder
    {
        ITagFinder OpenTagFinder { get; set; }

        ITagFinder CloseTagFinder { get; set; }

        IList<PlaceholderPosition> GetPlaceHolderPositions(string content);
    }

    public interface IPlaceholderReplacer
    {
        string ReplacePlaceholder(string content, string placeHolderContent);
    }

    public class PlaceholderReplacer : IPlaceholderReplacer
    {
        public IPlaceHolderFinder PlaceHolderFinder { get; set; }

        public PlaceholderReplacer()
        {
            PlaceHolderFinder = new PlaceHolderFinder();
        }

        public string ReplacePlaceholder(string content, string placeHolderContent)
        {
            var locations = PlaceHolderFinder.GetPlaceHolderPositions(content);

            if (locations.Count == 0)
                return content;

            var tempContent = content;

            var builder = new StringBuilder();

            var offset = 0;

            foreach (var location in locations)
            {
                var subContent = tempContent.Substring(0, location.StartPlaceholder - offset);
                builder.Append(subContent);
                builder.Append(placeHolderContent);

                offset = location.EndPlaceholder + PlaceHolderFinder.CloseTagFinder.Tag.Length + 1;
                if (offset > content.Length)
                {
                    break;
                }
                    
                tempContent = tempContent.Substring(offset);
            }

            var newContent = builder.ToString();

            return newContent;
        }
    }
}