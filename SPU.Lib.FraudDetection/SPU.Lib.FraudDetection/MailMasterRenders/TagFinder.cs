namespace SPU.Lib.FraudDetection.MailMasterRenders
{
    using System;
    using System.Collections.Generic;

    public class TagFinder : ITagFinder
    {
        private readonly IList<int> _tagPositions;
        private int _startIndex;

        public TagFinder()
        {
            _tagPositions = new List<int>();
            _startIndex = 0;
        }

        public string Tag { get; set; }

        public IList<int> GetTagPositions(string content)
        {
            FindTagsPositions(content);

            return _tagPositions;
        }

        private void FindTagsPositions(string content)
        {
            var index = content.IndexOf(Tag, _startIndex, StringComparison.OrdinalIgnoreCase);

            if (index < 0)
            {
                return;
            }

            _tagPositions.Add(index);

            _startIndex = _startIndex + index + Tag.Length + 1;

            if (_startIndex > content.Length)
            {
                return;
            }

            FindTagsPositions(content);
        }
    }
}