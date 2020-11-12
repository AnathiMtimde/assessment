using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DGSappSem2.Controllers
{
    public class PaymentController : Controller
    {
        // GET: Payment
        public ActionResult Index()
        {
            return View();
        }
    

        //public EventsController()
        //{
        //    this.payFastSettings = new PayFastSettings();
        //    this.payFastSettings.MerchantId = ConfigurationManager.AppSettings["MerchantId"];
        //    this.payFastSettings.MerchantKey = ConfigurationManager.AppSettings["MerchantKey"];
        //    this.payFastSettings.PassPhrase = ConfigurationManager.AppSettings["PassPhrase"];
        //    this.payFastSettings.ProcessUrl = ConfigurationManager.AppSettings["ProcessUrl"];
        //    this.payFastSettings.ValidateUrl = ConfigurationManager.AppSettings["ValidateUrl"];
        //    this.payFastSettings.ReturnUrl = ConfigurationManager.AppSettings["ReturnUrl"];
        //    this.payFastSettings.CancelUrl = ConfigurationManager.AppSettings["CancelUrl"];
        //    this.payFastSettings.NotifyUrl = ConfigurationManager.AppSettings["NotifyUrl"];
        //}
        //#region Fields

        //private readonly PayFastSettings payFastSettings;

        //#endregion Fields

        //#region Constructor

        ////public ApprovedOwnersController()
        ////{

        ////}

        //#endregion Constructor

        //#region Methods

        //public ActionResult Recurring()
        //{
        //    var recurringRequest = new PayFastRequest(this.payFastSettings.PassPhrase);

        //    // Merchant Details
        //    recurringRequest.merchant_id = this.payFastSettings.MerchantId;
        //    recurringRequest.merchant_key = this.payFastSettings.MerchantKey;
        //    recurringRequest.return_url = this.payFastSettings.ReturnUrl;
        //    recurringRequest.cancel_url = this.payFastSettings.CancelUrl;
        //    recurringRequest.notify_url = this.payFastSettings.NotifyUrl;

        //    // Buyer Details
        //    recurringRequest.email_address = "sbtu01@payfast.co.za";

        //    // Transaction Details
        //    recurringRequest.m_payment_id = "8d00bf49-e979-4004-228c-08d452b86380";
        //    recurringRequest.amount = 20;
        //    recurringRequest.item_name = "Recurring Option";
        //    recurringRequest.item_description = "Some details about the recurring option";

        //    // Transaction Options
        //    recurringRequest.email_confirmation = true;
        //    recurringRequest.confirmation_address = "drnendwandwe@gmail.com";

        //    // Recurring Billing Details
        //    recurringRequest.subscription_type = SubscriptionType.Subscription;
        //    recurringRequest.billing_date = DateTime.Now;
        //    recurringRequest.recurring_amount = 20;
        //    recurringRequest.frequency = BillingFrequency.Monthly;
        //    recurringRequest.cycles = 0;

        //    var redirectUrl = $"{this.payFastSettings.ProcessUrl}{recurringRequest.ToString()}";

        //    return Redirect(redirectUrl);
        //}

        //public ActionResult OnceOff()
        //{
        //    var onceOffRequest = new PayFastRequest(this.payFastSettings.PassPhrase);
        //    int ReservationID = int.Parse(Session["bookID"].ToString());
        //    Event èvent = new Event();
        //    èvent = db.Events.Find(ReservationID);
        //    var userName = User.Identity.Name;
        //    var guest = db.Customers.Where(x => x.Email == userName).FirstOrDefault();

        //    èvent.Status = "Deposit Paid, Await PickUp";
        //    èvent.Amount = èvent.Amount - èvent.AmountPaid;
        //    db.Entry(èvent).State = EntityState.Modified;
        //    db.SaveChanges();

        //    var attachments = new List<Attachment>();
        //    attachments.Add(new Attachment(new MemoryStream(GeneratePDF(ReservationID)), "Car Rental Receipt", "application/pdf"));


        //    var mailTo = new List<MailAddress>();
        //    mailTo.Add(new MailAddress(User.Identity.Name, guest.FirstName + guest.LastName));
        //    var body = $"Hello {guest.FirstName + guest.LastName}, Please see attached receipt for the recent rental you made. <br/>Make sure you bring along your receipt when you pick up your car.<br/>";
        //    Activities.Models.EmailService emailService = new Activities.Models.EmailService();
        //    emailService.SendEmail(new EmailContent()
        //    {
        //        mailTo = mailTo,
        //        mailCc = new List<MailAddress>(),
        //        mailSubject = "Application Statement | Ref No.:" + èvent.RefNum,
        //        mailBody = body,
        //        mailFooter = "<br/> Many Thanks, <br/> <b>Explorer</b>",
        //        mailPriority = MailPriority.High,
        //        mailAttachments = attachments

        //    });
        //    // Merchant Details
        //    onceOffRequest.merchant_id = this.payFastSettings.MerchantId;
        //    onceOffRequest.merchant_key = this.payFastSettings.MerchantKey;
        //    onceOffRequest.return_url = this.payFastSettings.ReturnUrl;
        //    onceOffRequest.cancel_url = this.payFastSettings.CancelUrl;
        //    onceOffRequest.notify_url = this.payFastSettings.NotifyUrl;

        //    // Buyer Details

        //    onceOffRequest.email_address = "sbtu01@payfast.co.za";
        //    //onceOffRequest.email_address = "sbtu01@payfast.co.za";

        //    // Transaction Details
        //    //onceOffRequest.m_payment_id = "";
        //    onceOffRequest.m_payment_id = èvent.RefNum;
        //    onceOffRequest.amount = Convert.ToDouble(èvent.AmountPaid);
        //    onceOffRequest.item_name = "Car Rental payment";
        //    onceOffRequest.item_description = "Some details about the once off payment";
        //    onceOffRequest.email_confirmation = true;
        //    onceOffRequest.confirmation_address = "sbtu01@payfast.co.za";

        //    var redirectUrl = $"{this.payFastSettings.ProcessUrl}{onceOffRequest.ToString()}";
        //    return Redirect(redirectUrl);
        //}

        //public ActionResult AdHoc()
        //{
        //    var adHocRequest = new PayFastRequest(this.payFastSettings.PassPhrase);

        //    // Merchant Details
        //    adHocRequest.merchant_id = this.payFastSettings.MerchantId;
        //    adHocRequest.merchant_key = this.payFastSettings.MerchantKey;
        //    adHocRequest.return_url = this.payFastSettings.ReturnUrl;
        //    adHocRequest.cancel_url = this.payFastSettings.CancelUrl;
        //    adHocRequest.notify_url = this.payFastSettings.NotifyUrl;

        //    // Buyer Details
        //    adHocRequest.email_address = "sbtu01@payfast.co.za";

        //    // Transaction Details
        //    adHocRequest.m_payment_id = "";
        //    adHocRequest.amount = 70;
        //    adHocRequest.item_name = "Adhoc Agreement";
        //    adHocRequest.item_description = "Some details about the adhoc agreement";

        //    // Transaction Options
        //    adHocRequest.email_confirmation = true;
        //    adHocRequest.confirmation_address = "sbtu01@payfast.co.za";

        //    // Recurring Billing Details
        //    adHocRequest.subscription_type = SubscriptionType.AdHoc;

        //    var redirectUrl = $"{this.payFastSettings.ProcessUrl}{adHocRequest.ToString()}";

        //    return Redirect(redirectUrl);
        //}

        //public ActionResult Return()
        //{
        //    return View();
        //}

        //public ActionResult Cancel()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<ActionResult> Notify([ModelBinder(typeof(PayFastNotifyModelBinder))] PayFastNotify payFastNotifyViewModel)
        //{
        //    payFastNotifyViewModel.SetPassPhrase(this.payFastSettings.PassPhrase);

        //    var calculatedSignature = payFastNotifyViewModel.GetCalculatedSignature();

        //    var isValid = payFastNotifyViewModel.signature == calculatedSignature;

        //    System.Diagnostics.Debug.WriteLine($"Signature Validation Result: {isValid}");

        //    // The PayFast Validator is still under developement
        //    // Its not recommended to rely on this for production use cases
        //    var payfastValidator = new PayFastValidator(this.payFastSettings, payFastNotifyViewModel, IPAddress.Parse(this.HttpContext.Request.UserHostAddress));

        //    var merchantIdValidationResult = payfastValidator.ValidateMerchantId();

        //    System.Diagnostics.Debug.WriteLine($"Merchant Id Validation Result: {merchantIdValidationResult}");

        //    var ipAddressValidationResult = payfastValidator.ValidateSourceIp();

        //    System.Diagnostics.Debug.WriteLine($"Ip Address Validation Result: {merchantIdValidationResult}");

        //    // Currently seems that the data validation only works for successful payments
        //    if (payFastNotifyViewModel.payment_status == PayFastStatics.CompletePaymentConfirmation)
        //    {
        //        var dataValidationResult = await payfastValidator.ValidateData();

        //        System.Diagnostics.Debug.WriteLine($"Data Validation Result: {dataValidationResult}");
        //    }

        //    if (payFastNotifyViewModel.payment_status == PayFastStatics.CancelledPaymentConfirmation)
        //    {
        //        System.Diagnostics.Debug.WriteLine($"Subscription was cancelled");
        //    }

        //    return new HttpStatusCodeResult(HttpStatusCode.OK);
        //}

        //public ActionResult Error()
        //{
        //    return View();
        //}

        //#endregion Methods

        //public byte[] GeneratePDF(int BookingID)
        //{
        //    MemoryStream memoryStream = new MemoryStream();
        //    Document document = new Document(PageSize.A5, 0, 0, 0, 0);
        //    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
        //    document.Open();

        //    Event @event = new Event();
        //    @event = db.Events.Find(BookingID);
        //    var userName = User.Identity.GetUserName();
        //    var guest = db.Customers.Where(x => x.Email == userName).FirstOrDefault();

        //    iTextSharp.text.Font font_heading_3 = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.RED);
        //    iTextSharp.text.Font font_body = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 9, iTextSharp.text.BaseColor.BLUE);

        //    // Create the heading paragraph with the headig font
        //    PdfPTable table1 = new PdfPTable(1);
        //    PdfPTable table2 = new PdfPTable(5);
        //    PdfPTable table3 = new PdfPTable(1);

        //    iTextSharp.text.pdf.draw.VerticalPositionMark seperator = new iTextSharp.text.pdf.draw.LineSeparator();
        //    seperator.Offset = -6f;
        //    // Remove table cell
        //    table1.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
        //    table3.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;

        //    table1.WidthPercentage = 80;
        //    table1.SetWidths(new float[] { 100 });
        //    table2.WidthPercentage = 80;
        //    table3.SetWidths(new float[] { 100 });
        //    table3.WidthPercentage = 80;

        //    PdfPCell cell = new PdfPCell(new Phrase(""));
        //    cell.Colspan = 3;
        //    table1.AddCell("\n");
        //    table1.AddCell(cell);
        //    table1.AddCell("\n\n");
        //    table1.AddCell(
        //        "\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t" +
        //        "Blue Sky Car Rental \n" +
        //        "Email :bluesky@carrental.co.za" + "\n" +
        //        "\n" + "\n");
        //    table1.AddCell("------------Personal Details--------------!");

        //    table1.AddCell("First Name : \t" + guest.FirstName);
        //    table1.AddCell("Last Name : \t" + guest.LastName);
        //    table1.AddCell("Email : \t" + guest.Email);
        //    table1.AddCell("Phone Number : \t" + guest.ContactNo);
        //    table1.AddCell("Gender : \t" + guest.Gender);
        //    table1.AddCell("Address : \t" + guest.Address);

        //    table1.AddCell("\n------------Rented car details--------------!\n");

        //    table1.AddCell("Car Type : \t" + @event.CarType);
        //    table1.AddCell("Car Model : \t" + @event.CarModel);
        //    table1.AddCell("Model Year : \t" + @event.CarYear);
        //    table1.AddCell("Number of Doors: \t" + @event.Doors);
        //    table1.AddCell("Number of Seats: \t" + @event.Seats);

        //    table1.AddCell("\n------------Rental details--------------!\n");

        //    table1.AddCell("Rental Ref. # : \t" + @event.RefNum);
        //    table1.AddCell("PickUp date : \t" + @event.PickUpDate.ToShortDateString());
        //    table1.AddCell("DropOut date : \t" + @event.DropOutDate.ToShortDateString());
        //    table1.AddCell("Number Of days : \t" + @event.Duration);
        //    table1.AddCell("Total Rental Cost Due: \t" + @event.Amount.ToString("C"));
        //    table1.AddCell("Amount Paid: \t" + @event.AmountPaid.ToString("C"));
        //    table1.AddCell("Status : \t" + @event.Status);
        //    table1.AddCell("Deposit Payed date : \t" + DateTime.Now);

        //    table1.AddCell("\n");

        //    table3.AddCell("------------Looking forward to hear from you soon--------------!");

        //    //////Intergrate information into 1 document
        //    //var qrCode = iTextSharp.text.Image.GetInstance(reservation.QrCodeImage);
        //    //qrCode.ScaleToFit(200, 200);
        //    table1.AddCell(cell);
        //    document.Add(table1);
        //    //document.Add(qrCode);
        //    document.Add(table3);
        //    document.Close();

        //    byte[] bytes = memoryStream.ToArray();
        //    memoryStream.Close();
        //    return bytes;
        //}

    }
}