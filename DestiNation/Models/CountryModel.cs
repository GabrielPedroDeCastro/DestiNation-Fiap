using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DestiNation.Models
{
    [Table ("COUNTRY")]
    public class CountryModel
    {
        [Key]
        [Column("COUNTRYID")]
        public int CountryId { get; set; }

        [Column("COUNTRYNAME")]
        [Required(ErrorMessage = "The country`s name is required!")]
        [StringLength(100)]
        public string CountryName { get; set; }

        [Column("COUNTRYCAPITAL")]
        [Required(ErrorMessage = "The country`s capital is required!")]
        [StringLength(100)]
        public string Capital { get; set; }

        [Column("COUNTRYCURRENCY")]
        [Required(ErrorMessage = "The country`s currency is required!")]
        [StringLength(100)]
        public string Currency { get; set; }

        [Column("COUNTRYCONT")]
        [Required(ErrorMessage = "The country`s continent is required!")]
        [StringLength(100)]
        public string Continent { get; set; }

        [Column("COUNTRYLANG")]
        [Required(ErrorMessage = "The country`s language is required!")]
        [StringLength(100)]
        public string Languages { get; set; }

        [Column("COUNTRYPOP")]
        [Required(ErrorMessage = "The country`s population is required!")]
        [StringLength(100)]
        public string Population { get; set; }

        public CountryModel(int countryId, string nameCountry)
        {
            CountryId = countryId;
            CountryName = nameCountry;

        }

        public CountryModel(int countryId, string countryName, string countryCapital)
        {
            CountryId = countryId;
            CountryName = countryName;
            Capital = countryCapital;

        }

        public CountryModel(int countryId, string countryName, string capital, string currency, string continent, string languages, string population) : this(countryId, countryName, capital)
        {
            Currency = currency;
            Continent = continent;
            Languages = languages;
            Population = population;
        }

        public CountryModel(int id)
        {
            CountryId = id;
        }
    }
}
