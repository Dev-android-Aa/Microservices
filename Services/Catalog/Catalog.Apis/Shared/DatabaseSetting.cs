namespace Catalog.Apis.Shared
{
    public class DatabaseSetting
    {
        // relation beetwen setting.jason and this class 
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }

        public string? CollectionName { get; set; }

    }
}
