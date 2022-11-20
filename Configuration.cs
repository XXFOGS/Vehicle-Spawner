using System.Xml;
using System.Xml.Serialization;
using Rocket.API;
using UnityEngine;

namespace VehicleSpawner
{
    public sealed class SpawnNode
    {
        public float X;
        public float Y;
        public float Z;

        public SpawnNode(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    public sealed class Vehicle
    {
        [XmlAttribute("ID")]
        public ushort Id;

        public Vehicle(ushort id)
        {
            Id = id;
        }
        public Vehicle()
        {
            Id = ushort.MinValue;
        }
    }

    public class Configuration : IRocketPluginConfiguration
    {
        public int Interval;
        public bool Enabled;

        [XmlArrayItem("Vehicle")]
        [XmlArray(ElementName = "Vehicles")]
        public Vehicle[] Vehicles;

        public void LoadDefaults()
        {
            Interval = 3600;
            Enabled = true;
            Vehicles = new Vehicle[]
            {
                new Vehicle(1),
                new Vehicle(2),
                new Vehicle(3),
                new Vehicle(4),
                new Vehicle(5),
                new Vehicle(6),
                new Vehicle(7),
                new Vehicle(8),
                new Vehicle(9),
                new Vehicle(10),
                new Vehicle(11),
                new Vehicle(12),
                new Vehicle(13),
                new Vehicle(14),
                new Vehicle(15),
                new Vehicle(16),
                new Vehicle(17),
                new Vehicle(18),
                new Vehicle(19),
                new Vehicle(20),
                new Vehicle(21),
                new Vehicle(22),
                new Vehicle(23),
                new Vehicle(24),
                new Vehicle(25),
                new Vehicle(26),
                new Vehicle(27),
                new Vehicle(28),
                new Vehicle(29),
                new Vehicle(30),
                new Vehicle(31),
                new Vehicle(32),
                new Vehicle(33),
                new Vehicle(34),
                new Vehicle(35),
                new Vehicle(36),
                new Vehicle(37),
                new Vehicle(38),
                new Vehicle(39),
                new Vehicle(40),
                new Vehicle(41),
                new Vehicle(42),
                new Vehicle(43),
                new Vehicle(44),
                new Vehicle(45),
                new Vehicle(46),
                new Vehicle(47),
                new Vehicle(48),
                new Vehicle(49),
                new Vehicle(50),
                new Vehicle(51),
                new Vehicle(52),
                new Vehicle(53),
                new Vehicle(54),
                new Vehicle(55),
                new Vehicle(56),
                new Vehicle(57),
                new Vehicle(58),
                new Vehicle(59),
                new Vehicle(60),
                new Vehicle(61),
                new Vehicle(62),
                new Vehicle(63),
                new Vehicle(64),
                new Vehicle(65),
                new Vehicle(66),
                new Vehicle(67),
                new Vehicle(68),
                new Vehicle(69),
                new Vehicle(70),
                new Vehicle(71),
                new Vehicle(72),
                new Vehicle(73),
                new Vehicle(74),
                new Vehicle(75),
                new Vehicle(76),
                new Vehicle(77),
                new Vehicle(78),
                new Vehicle(79),
                new Vehicle(80),
                new Vehicle(81),
                new Vehicle(82),
                new Vehicle(83),
                new Vehicle(84),
                new Vehicle(85),
                new Vehicle(86),
                new Vehicle(87),
                new Vehicle(88),
                new Vehicle(89),
                new Vehicle(90),
                new Vehicle(91),
                new Vehicle(92),
                new Vehicle(93),
                new Vehicle(94),
                new Vehicle(95),
                new Vehicle(96),
                new Vehicle(97),
              /*new Vehicle(98),
                new Vehicle(99),
                new Vehicle(100),
                new Vehicle(101),
                new Vehicle(102),
                new Vehicle(103),
                new Vehicle(104),
                new Vehicle(105),*/
                new Vehicle(106),
                new Vehicle(107),
              //new Vehicle(108),
                new Vehicle(109),
                new Vehicle(110),
                new Vehicle(111),
                new Vehicle(112),
                new Vehicle(113),
                new Vehicle(114),
                new Vehicle(115),
                new Vehicle(116),
                new Vehicle(117),
                new Vehicle(118),
                new Vehicle(119),
                new Vehicle(120),
                new Vehicle(121),
                new Vehicle(122),
                new Vehicle(123),
              //new Vehicle(124),
                new Vehicle(125),
                new Vehicle(126),
                new Vehicle(127),
                new Vehicle(128),
                new Vehicle(129),
                new Vehicle(130),
                new Vehicle(131),
                new Vehicle(132),
                new Vehicle(133),
                new Vehicle(134),
                new Vehicle(135),
                new Vehicle(136),
                new Vehicle(137),
                new Vehicle(138),
                new Vehicle(139),
                new Vehicle(140),
                new Vehicle(141),
                new Vehicle(142),
                new Vehicle(143),
                new Vehicle(144),
                new Vehicle(145),
                new Vehicle(146),
                new Vehicle(147),
                new Vehicle(148),
                new Vehicle(149),
                new Vehicle(150),
                new Vehicle(151),
                new Vehicle(152),
                new Vehicle(153),
                new Vehicle(154),
                new Vehicle(155),
                new Vehicle(156),
                new Vehicle(157),
                new Vehicle(158),
                new Vehicle(159),
                new Vehicle(160),
                new Vehicle(161),
                new Vehicle(162),
                new Vehicle(163),
                new Vehicle(164),
                new Vehicle(165),
                new Vehicle(166),
                new Vehicle(167),
                new Vehicle(168),
                new Vehicle(169)
            };
        }
    }
}
