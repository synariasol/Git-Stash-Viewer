namespace GSV
{
    public sealed class StashFileInfo
    {
        public enum ChangeStatusTypes
        {
            Added,
            Modified,
            Deleted,
            Untracked
        }

        public string Name { get; set; }

        public string Diff { get; set; }

        public string Hash { get; set; }

        public ChangeStatusTypes ChangeStatus { get; set; }
    }
}