﻿namespace Quadro.Interface.Orders
{
	public interface IOrderEntity
    {
        string? CustomerId { get; set; }
        string OrderDescription { get; set; }
        string OrderNumber { get; set; }
        IEnumerable<IOrderLine> Lines { get; }
        IEnumerable<IQuoteDto> Quotes { get; }
        IEnumerable<IManufacturingOrder> ManufacturingOrders { get; }
        IEnumerable<ISubOrderDto> SubOrders { get; }
    }
}