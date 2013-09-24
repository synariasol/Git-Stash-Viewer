using System.Collections.Generic;

namespace GSV
{
    public sealed class StashInfo
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<StashFileInfo> Files { get; set; }
    }
}