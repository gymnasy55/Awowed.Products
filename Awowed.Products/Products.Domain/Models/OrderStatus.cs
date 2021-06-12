namespace Products.Domain.Models
{
    public enum OrderStatus
    {
        New,
        CanceledByAdmin,
        CanceledByUser,
        ReceivedPayment,
        Sent,
        Received,
        Done
    }
}