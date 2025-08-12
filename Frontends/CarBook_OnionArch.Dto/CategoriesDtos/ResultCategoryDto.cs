namespace CarBook_OnionArch.Dto.CategoriesDtos
{
    public class ResultCategoryDto
    {
            public int id { get; set; }
            public string name { get; set; }
            public object[] blogs { get; set; }
            public bool isDeleted { get; set; }
        }
}
