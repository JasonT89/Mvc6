using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc6.Models
{
    public class Fever
    {
        private const float FEVER_THRESHOLD_C = 38f;
        private const float FEVER_THRESHOLD_F = 100.4f;
        private const float HYPOTHERMIA_THRESHOLD_C = 35f;
        private const float HYPOTHERMIA_THRESHOLD_F = 95f;

        public static bool HasFever(float temperature, bool useFarenheit)
        {
            if (!useFarenheit)
            {
                return temperature > FEVER_THRESHOLD_C;
            }
            else
            {
                return temperature > FEVER_THRESHOLD_F;
            }
        }

        public static bool HasHypothermia(float temperature, bool useFarenheit)
        {
            if (!useFarenheit)
            {
                return temperature < HYPOTHERMIA_THRESHOLD_C;
            }
            else
            {
                return temperature < HYPOTHERMIA_THRESHOLD_F;
            }
        }
    }
}