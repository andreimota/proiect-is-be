using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProiectIS_BE.Models.Exercise
{
    public class ExercisePreviewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string StartingCode { get; set; }
        public string Difficulty { get; set; }
        public string Technology { get; set; }
    }
}
