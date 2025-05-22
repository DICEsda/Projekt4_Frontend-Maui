using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceTracker.Services;
using FinanceTracker.ViewModels;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;

namespace FinanceTracker.Views;

public partial class PayCheckPage : ContentPage
{

    public PayCheckPage(PayCheckViewModel payCheckViewModel)
    {
        InitializeComponent();
        BindingContext = payCheckViewModel;
    }

    private async void OnFetchTapped(object sender, EventArgs e)
    {
        if (BindingContext is PayCheckViewModel vm)
        {
            string company = CompanyEntry.Text;
            int.TryParse(MonthEntry.Text, out int month);

            await vm.SalaryEstimationForMonthCommand.ExecuteAsync((company, month));
        }
    }

    private void Button_OnClicked(object? sender, EventArgs e)
    {
        if (BindingContext is not PayCheckViewModel vm)
            return;

        string filename = "paychecksummary.pdf";
        string filePath = Path.Combine(FileSystem.AppDataDirectory, filename);

        using (PdfWriter writer = new PdfWriter(filePath))
        {
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            document.Add(new Paragraph("Lønseddel").SetFontSize(20).SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER));
            document.Add(new Paragraph($"Virksomhed: {vm.CompanyName}"));
            document.Add(new Paragraph($"Måned: {vm.Month}"));

            document.Add(new Paragraph("\nEstimeret løn"));
            document.Add(new Paragraph($"Løn før skat: {vm.SalaryBeforeTax}"));
            document.Add(new Paragraph($"Arbejdstimer: {vm.WorkedHours}"));
            document.Add(new Paragraph($"AM-bidrag: {vm.AmContribution}"));
            document.Add(new Paragraph($"Skat i %: {vm.Tax}"));
            document.Add(new Paragraph($"Løn efter skat: {vm.SalaryAfterTax}"));

            document.Add(new LineSeparator(new SolidLine()));

            document.Add(new Paragraph("Faktisk løn"));
            document.Add(new Paragraph($"Løn før skat: {vm.SalaryBeforeTaxActual}"));
            document.Add(new Paragraph($"Arbejdstimer: {vm.WorkedHoursActual}"));
            document.Add(new Paragraph($"AM-bidrag: {vm.AmContributionActual}"));
            document.Add(new Paragraph($"Skat i %: {vm.TaxActual}"));
            document.Add(new Paragraph($"Løn efter skat: {vm.SalaryAfterTaxActual}"));

            document.Close();
        }

        // Evt. vis en bekræftelse
        Application.Current.MainPage.DisplayAlert("PDF Genereret", $"PDF gemt i:\n{filePath}", "OK");
    }


}
