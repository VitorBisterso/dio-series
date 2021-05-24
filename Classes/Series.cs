using System;

namespace dio_series
{
    public class Series : BaseEntity
    {
        private Categories Category { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool IsActive { get; set; }

        public Series(int id, Categories category, string title, string description, int year)
        {
            this.Id = id;
            this.Category = category;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.IsActive = true;
        }

        public override string ToString()
        {
            string information = "";

            information += "Gênero: " + this.Category + Environment.NewLine;
            information += "Título: " + this.Title + Environment.NewLine;
            information += "Descrição: " + this.Description + Environment.NewLine;
            information += "Ano de início: " + this.Year + Environment.NewLine;
            information += "Registro ativo: " + (this.IsActive ? "Sim" : "Não");

            return information;
        }

        public string GetTitle()
        {
            return this.Title;
        }

        public int GetId()
        {
            return this.Id;
        }

        public bool GetIsActive()
        {
            return this.IsActive;
        }

        public void RemoveSeries()
        {
            this.IsActive = false;
        }
    }
}