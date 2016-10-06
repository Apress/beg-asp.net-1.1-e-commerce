SET IDENTITY_INSERT Status ON
INSERT INTO Status (StatusID, Description) VALUES(0, 'Order placed, notifying customer')
INSERT INTO Status (StatusID, Description) VALUES(1, 'Awaiting confirmation of funds')
INSERT INTO Status (StatusID, Description) VALUES(2, 'Notifying supplier – stock check')
INSERT INTO Status (StatusID, Description) VALUES(3, 'Awaiting stock confirmation')
INSERT INTO Status (StatusID, Description) VALUES(4, 'Awaiting credit card payment')
INSERT INTO Status (StatusID, Description) VALUES(5, 'Notifying supplier – shipping')
INSERT INTO Status (StatusID, Description) VALUES(6, 'Awaiting shipment confirmation')
INSERT INTO Status (StatusID, Description) VALUES(7, 'Sending final notification')
INSERT INTO Status (StatusID, Description) VALUES(8, 'Order completed')
SET IDENTITY_INSERT Status OFF
