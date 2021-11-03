using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BenefitDeductionAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            #region"Data Managers Dependency Injections" 
            services.AddScoped<BenefitDeduction.Employees.IEmployeeRepository,BenefitDeduction.Employees.EmployeeRepository > ();
            services.AddScoped<BenefitDeduction.Employees.FamilyMembers.IFamilyMemberSpouseRepository, BenefitDeduction.Employees.FamilyMembers.EmployeeSpouseRepository> ();
            services.AddScoped<BenefitDeduction.Employees.FamilyMembers.IFamilyMemberChildRepository, BenefitDeduction.Employees.FamilyMembers.EmployeeChildRepository> ();
            services.AddScoped<BenefitDeduction.Employees.Exempts.IEmployeeExemptRepository, BenefitDeduction.Employees.Exempts.EmployeeExemptRepository >();

            services.AddScoped<BenefitDeduction.EmployeesSalary.ISalaryRepository,BenefitDeduction.EmployeesSalary.SalaryRepository > ();
            services.AddScoped<BenefitDeduction.EmployeesSalary.Employees.ISalaryEmployeeExemptRepository,BenefitDeduction.EmployeesSalary.Employees.SalaryEmployeeExemptRepository> ();

            services.AddScoped<BenefitDeduction.EmployeeBenefitDeduction.IBenefitDeductionRepository,BenefitDeduction.EmployeeBenefitDeduction.BenefitDeductionRepository > ();
            services.AddScoped<BenefitDeduction.EmployeeBenefitDeduction.Employees.IDeductionEmployeeRepository,BenefitDeduction.EmployeeBenefitDeduction.Employees.DeductionEmployeeRepository> ();
            services.AddScoped<BenefitDeduction.EmployeeBenefitDeduction.Employees.Calculators.ICalculateDeductionItemsRespository, BenefitDeduction.EmployeeBenefitDeduction.Employees.Calculators.CalculateDeductionItemsRespository> ();
            services.AddScoped<BenefitDeduction.EmployeeBenefitDeduction.Employees.Calculators.ICalculateDeductionDetailRespository, BenefitDeduction.EmployeeBenefitDeduction.Employees.Calculators.CalculateDeductionDetailRespository> ();

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());


            app.UseMvc();
        }
    }
}
