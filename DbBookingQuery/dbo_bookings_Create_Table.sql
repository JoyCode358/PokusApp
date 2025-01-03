USE [HotelBooking]
GO

/****** Object:  Table [dbo].[Bookings]    Script Date: 22. 7. 2024 12:59:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Bookings](
	[Id] [int] NOT NULL IDENTITY(1,1),
	[RoomNumber] [int] NOT NULL,
	[ClientsName] [nvarchar](50) NULL,
	[Description] [nvarchar](50) NULL,
	[Adress] [nvarchar](50) NULL,
 CONSTRAINT [PK_Bookings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Bookings]  WITH CHECK ADD  CONSTRAINT [FK_Bookings_Bookings] FOREIGN KEY([Id])
REFERENCES [dbo].[Bookings] ([Id])
GO

ALTER TABLE [dbo].[Bookings] CHECK CONSTRAINT [FK_Bookings_Bookings]
GO


