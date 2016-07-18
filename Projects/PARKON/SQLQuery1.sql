DBCC CHECKIDENT ('bookingRegistration', RESEED, 0)
delete from bookingRegistration;
select booking_no from bookingRegistration where Bid=1