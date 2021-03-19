namespace ConsoleSeries
{
    public class Series : BaseEntity
    {
        public Genre Genre { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        private bool Deleted { get; set; }
    
        public Series(Genre genre, string title, string description, int year)
        {
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deleted = false;
        }

        public override string ToString()
        {
            string serie = $"Título: {this.Title} / Gênero: {this.Genre} / "
            + $"Ano: {this.Year} \nDescrição: {this.Description}";

            return serie; 
        }

        public string GetTitle(){
            return this.Title;
        }

        public int GetId(){
            return this.id;
        }

        public void Delete(){
            this.Deleted = true;
        }

    }
}