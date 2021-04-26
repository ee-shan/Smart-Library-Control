-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 26, 2021 at 07:41 AM
-- Server version: 10.4.18-MariaDB
-- PHP Version: 8.0.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `tinylibrary`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`username`, `password`) VALUES
('root', 'toor');

-- --------------------------------------------------------

--
-- Table structure for table `books`
--

CREATE TABLE `books` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `publish_year` int(11) NOT NULL,
  `writer_name` varchar(50) NOT NULL,
  `quantity` int(11) NOT NULL,
  `category_id` int(11) NOT NULL,
  `entry_date` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `books`
--

INSERT INTO `books` (`id`, `name`, `publish_year`, `writer_name`, `quantity`, `category_id`, `entry_date`) VALUES
(1, 'Angels & Demons', 2000, 'Dan Brown', 20, 1, '22-Apr-21 12:00:00 AM'),
(2, 'A Study in Scarlet', 1887, 'Arthur Conan Doyle', 20, 2, '22-Apr-21 12:00:00 AM'),
(3, 'The Sign of Four', 1890, 'Arthur Conan Doyle', 9, 2, '22-Apr-21 12:00:00 AM'),
(4, 'ফেলুদার গোয়েন্দাগিরি', 1970, 'Satyajit Ray', 50, 2, '22-Apr-21 12:00:00 AM'),
(5, 'Treasure Island', 1883, 'R. L. Stevenson', 20, 3, '22-Apr-21 12:00:00 AM'),
(6, 'Kidnapped', 1886, 'R. L. Stevenson', 10, 3, '23-Apr-21 12:00:00 AM'),
(7, 'The Da Vinci Code', 2003, 'Dan Brown', 30, 1, '23-Apr-21 12:00:00 AM'),
(8, 'চাঁদের পাহাড়', 1937, 'Bibhutibhushan Bandyopadyay', 50, 3, '23-Apr-21 12:00:00 AM'),
(9, 'Origin', 2017, 'Dan Brown', 10, 1, '23-Apr-21 12:00:00 AM'),
(10, 'গ্যাংটকে গণ্ডগোল', 1971, 'Satyajit Ray', 48, 2, '23-Apr-21 12:00:00 AM'),
(11, 'সোনার কেল্লা', 1971, 'Satyajit Ray', 50, 2, '23-Apr-21 12:00:00 AM'),
(12, 'The Lost Symbol', 2009, 'Dan Brown', 10, 1, '23-Apr-21 12:00:00 AM'),
(13, 'Chronicles, Volume One', 2004, 'Bob Dylan', 20, 5, '24-Apr-21 12:00:00 AM'),
(14, 'বাদশাহী আংটি', 1969, 'Satyajit Ray', 50, 2, '24-Apr-21 12:00:00 AM'),
(15, 'Pride and Prejudice', 1813, 'Jane Austen', 10, 4, '24-Apr-21 12:00:00 AM'),
(16, 'The Invisible Man', 1897, 'H. G. Wells', 14, 6, '24-Apr-21 12:00:00 AM');

-- --------------------------------------------------------

--
-- Table structure for table `category`
--

CREATE TABLE `category` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `category`
--

INSERT INTO `category` (`id`, `name`) VALUES
(1, 'Thriller'),
(2, 'Detective'),
(3, 'Adventure'),
(4, 'Romance'),
(5, 'Memoir'),
(6, 'Science Fiction');

-- --------------------------------------------------------

--
-- Table structure for table `history`
--

CREATE TABLE `history` (
  `user_id` int(11) NOT NULL,
  `book_id` int(11) NOT NULL,
  `lend_date` varchar(50) NOT NULL,
  `return_state` varchar(50) NOT NULL,
  `return_date` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `history`
--

INSERT INTO `history` (`user_id`, `book_id`, `lend_date`, `return_state`, `return_date`) VALUES
(1, 8, 'Saturday, April 24, 2021', 'returned', 'Saturday, April 24, 2021'),
(1, 4, 'Saturday, April 24, 2021', 'returned', 'Monday, April 26, 2021'),
(1, 7, 'Saturday, April 24, 2021', 'returned', 'Saturday, April 24, 2021'),
(2, 13, 'Saturday, April 24, 2021', 'returned', 'Sunday, April 25, 2021'),
(2, 10, 'Saturday, April 24, 2021', 'not returned', ''),
(1, 10, 'Saturday, April 24, 2021', 'not returned', ''),
(1, 16, 'Sunday, April 25, 2021', 'returned', 'Sunday, April 25, 2021'),
(3, 3, 'Monday, April 26, 2021', 'not returned', '');

-- --------------------------------------------------------

--
-- Table structure for table `managers`
--

CREATE TABLE `managers` (
  `Name` varchar(50) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `managers`
--

INSERT INTO `managers` (`Name`, `username`, `password`) VALUES
('Azizul Hakim', 'ahakim', 'ahakim'),
('Joseph Sykora', 'sykora', 'sykora'),
('Firoza Begum', 'firoza', 'firoza');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `name`) VALUES
(1, 'Bijan Paul'),
(2, 'Azizul Hakim Eshan'),
(3, 'Humayun Fakir');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `books`
--
ALTER TABLE `books`
  ADD PRIMARY KEY (`id`),
  ADD KEY `category_id` (`category_id`);

--
-- Indexes for table `category`
--
ALTER TABLE `category`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `history`
--
ALTER TABLE `history`
  ADD KEY `user_id` (`user_id`),
  ADD KEY `book_id` (`book_id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `books`
--
ALTER TABLE `books`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `category`
--
ALTER TABLE `category`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `books`
--
ALTER TABLE `books`
  ADD CONSTRAINT `books_ibfk_1` FOREIGN KEY (`category_id`) REFERENCES `category` (`id`);

--
-- Constraints for table `history`
--
ALTER TABLE `history`
  ADD CONSTRAINT `history_ibfk_1` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `history_ibfk_2` FOREIGN KEY (`book_id`) REFERENCES `books` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
