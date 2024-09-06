use HotelManager
CREATE TABLE rooms (
  room_id INT NOT NULL identity,
  room_type VARCHAR(50) ,
  status VARCHAR(50) ,
  price FLOAT,
  PRIMARY KEY (room_id)
);
CREATE TABLE customers (
  customer_id INT NOT NULL identity,
  name VARCHAR(100) ,
  phone_number VARCHAR(20) ,
  email VARCHAR(100) ,
  address VARCHAR(200),
  PRIMARY KEY (customer_id)
);
CREATE TABLE bookings (
  booking_id INT NOT NULL identity,
  customer_id INT ,
  room_id INT ,
  checkin_date DATE ,
  checkout_date DATE ,
  total_price FLOAT ,
  PRIMARY KEY (booking_id),
  FOREIGN KEY (customer_id) REFERENCES customers (customer_id),
  FOREIGN KEY (room_id) REFERENCES rooms (room_id)
);

INSERT INTO rooms (room_type, status, price) VALUES
('Single', 'booking', 1000000),
('Double', 'notset', 1500000),
('Suite', 'notset', 2000000);

INSERT INTO customers (name, phone_number, email, address) VALUES
('Nguyen Quang Vinh', '0978616006', 'vinh@gmail.com', 'Thuong Tin, Ha Noi'),
('Nguyen Van Manh', '09786666666', 'manh@gmail.com', '456 Ly Thuong Kiet, Ha Noi'),
('Nguyen Phu Lam', '09786666666', 'Lam@gmail.com', 'Ha Dong, Ha Noi'),
('Nguyen Thai Bao', '0978111111', 'bao@gmail.com', 'Hoan Kiem, Ha Noi');

INSERT INTO bookings (customer_id, room_id, checkin_date, checkout_date, total_price) VALUES
(1, 1, '2024-01-15', '2024-01-17', 2000000),
(2, 2, '2024-01-18', '2024-01-12', 3000000);
