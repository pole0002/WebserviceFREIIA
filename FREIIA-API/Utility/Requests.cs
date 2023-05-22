using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FREIIA_API.Data;
using FREIIA_API.Models;

namespace FREIIA_API.Utility
{
    public class Requests
    {
        private readonly FREIIAContext _context;

        public Requests(FREIIAContext context)
        {
            _context = context;
        }
        public Chart GetChartById(int chartId)
        {
            Chart chart = _context.Charts //gets chart objects
                .Include(c => c.Zones) //includes zones that are connected to specified chart
                .SingleOrDefault(c => c.Id == chartId); //selects the chart that corresponds to the entered chartID
            return chart;
        }
        public async Task SaveChartAsync(Chart chart)
        {
            _context.Update(chart); //updates the chart object in the DB that corresponds to the incoming chart
            await _context.SaveChangesAsync(); //saves changes to DB.
        }
    }
}
