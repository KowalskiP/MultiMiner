﻿using MultiMiner.Xgminer.Data;
using System.Collections.Generic;

namespace MultiMiner.Engine.Helpers
{
    public static class DonationPools
    {
        public static void Seed(List<Data.Configuration.Coin> configurations)
        {
            Data.Configuration.Coin donationConfiguration;

            //BTC
            donationConfiguration = CreateCoinConfiguration("BTC", "stratum+tcp://stratum.mining.eligius.st", 3334, "1LKwyLK4KhojsJUEvUx8bEmnmjohNMjRDM");
            configurations.Add(donationConfiguration);


            //LTC
            donationConfiguration = CreateCoinConfiguration("LTC", "stratum+tcp://freedom.wemineltc.com", 3334);
            configurations.Add(donationConfiguration);

            //BQC
            donationConfiguration = CreateCoinConfiguration("BQC", "stratum+tcp://www.bbqpool.net", 3333);
            configurations.Add(donationConfiguration);

            //FTC
            donationConfiguration = CreateCoinConfiguration("FTC", "stratum+tcp://stratum.wemineftc.com", 4444);
            configurations.Add(donationConfiguration);

            //MEC
            donationConfiguration = CreateCoinConfiguration("MEC", "stratum+tcp://us.miningpool.co", 9002);
            configurations.Add(donationConfiguration);

            //PPC
            donationConfiguration = CreateCoinConfiguration("PPC", "stratum+tcp://stratum.d7.lt", 3333);
            configurations.Add(donationConfiguration);

            //NVC
            donationConfiguration = CreateCoinConfiguration("NVC", "stratum+tcp://stratum.khore.org", 3334);
            configurations.Add(donationConfiguration);

            //CAP
            donationConfiguration = CreateCoinConfiguration("CAP", "stratum+tcp://cap.coinmine.pl", 8102);
            configurations.Add(donationConfiguration);

            //ZET
            donationConfiguration = CreateCoinConfiguration("ZET", "stratum+tcp://mine1.coinmine.pl", 6000);
            configurations.Add(donationConfiguration);

            //UNO
            donationConfiguration = CreateCoinConfiguration("UNO", "stratum+tcp://de1.miningpool.co", 10701);
            configurations.Add(donationConfiguration);

            //DOGE
            donationConfiguration = CreateCoinConfiguration("DOGE", "stratum+tcp://stratum.dogehouse.org", 3333);
            configurations.Add(donationConfiguration);

            //DOG
            donationConfiguration = CreateCoinConfiguration("DOG", "stratum+tcp://stratum.dogehouse.org", 3333);
            configurations.Add(donationConfiguration);

            //ASC
            donationConfiguration = CreateCoinConfiguration("ASC", "stratum+tcp://de1.miningpool.co", 10601);
            configurations.Add(donationConfiguration);

            //DGC
            donationConfiguration = CreateCoinConfiguration("DGC", "stratum+tcp://us.miningpool.co", 9102);
            configurations.Add(donationConfiguration);

            //FST
            donationConfiguration = CreateCoinConfiguration("FST", "stratum+tcp://de1.miningpool.co", 9203);
            configurations.Add(donationConfiguration);

            //FRK
            donationConfiguration = CreateCoinConfiguration("FRK", "stratum+tcp://de2.miningpool.co", 4101);
            configurations.Add(donationConfiguration);

            //GLC
            donationConfiguration = CreateCoinConfiguration("GLC", "stratum+tcp://de3.miningpool.co", 3905);
            configurations.Add(donationConfiguration);

            //GDC
            donationConfiguration = CreateCoinConfiguration("GDC", "stratum+tcp://us.miningpool.co", 10001);
            configurations.Add(donationConfiguration);

            //XJO
            donationConfiguration = CreateCoinConfiguration("XJO", "stratum+tcp://de1.miningpool.co", 11001);
            configurations.Add(donationConfiguration);

            //MOON
            donationConfiguration = CreateCoinConfiguration("MOON", "stratum+tcp://ca1.miningpool.co", 9999);
            configurations.Add(donationConfiguration);

            //SBC
            donationConfiguration = CreateCoinConfiguration("SBC", "stratum+tcp://au1.miningpool.co", 9203);
            configurations.Add(donationConfiguration);

            //QRK
            donationConfiguration = CreateCoinConfiguration("QRK", "stratum+tcp://mine1.coinmine.pl", 6010);
            configurations.Add(donationConfiguration);

            //SPT
            donationConfiguration = CreateCoinConfiguration("SPT", "stratum+tcp://spt.coinmine.pl", 9108);
            configurations.Add(donationConfiguration);

            //SRC
            donationConfiguration = CreateCoinConfiguration("SRC", "stratum+tcp://mine2.coinmine.pl", 6020);
            configurations.Add(donationConfiguration);

            //WDC
            donationConfiguration = CreateCoinConfiguration("WDC", "stratum+tcp://wdc.coinmine.pl", 9090);
            configurations.Add(donationConfiguration);

            //YBC
            donationConfiguration = CreateCoinConfiguration("YBC", "stratum+tcp://ybc.coinmine.pl", 9104);
            configurations.Add(donationConfiguration);

            //LEAF
            donationConfiguration = CreateCoinConfiguration("LEAF", "stratum+tcp://de3.miningpool.co", 3931);
            configurations.Add(donationConfiguration);

            //CNC
            donationConfiguration = CreateCoinConfiguration("CNC", "stratum+tcp://cnc.blocksolved.com", 3301);
            configurations.Add(donationConfiguration);

            //BEC
            donationConfiguration = CreateCoinConfiguration("CNC", "stratum+tcp://ca1.miningpool.co", 20001);
            configurations.Add(donationConfiguration);

            //BIC
            donationConfiguration = CreateCoinConfiguration("BIC", "stratum+tcp://de2.miningpool.co", 3388);
            configurations.Add(donationConfiguration);

            //DGB
            donationConfiguration = CreateCoinConfiguration("DGB", "stratum+tcp://de2.miningpool.co", 3399);
            configurations.Add(donationConfiguration);

            //ICO
            donationConfiguration = CreateCoinConfiguration("ICO", "stratum+tcp://de2.miningpool.co", 3391);
            configurations.Add(donationConfiguration);

            //KDC
            donationConfiguration = CreateCoinConfiguration("KDC", "stratum+tcp://de3.miningpool.co", 3902);
            configurations.Add(donationConfiguration);

            //MINT
            donationConfiguration = CreateCoinConfiguration("MINT", "stratum+tcp://de3.miningpool.co", 3356);
            configurations.Add(donationConfiguration);

            //MRY
            donationConfiguration = CreateCoinConfiguration("MRY", "stratum+tcp://ca1.miningpool.co", 14322);
            configurations.Add(donationConfiguration);

            //PLT
            donationConfiguration = CreateCoinConfiguration("PLT", "stratum+tcp://de2.miningpool.co", 9501);
            configurations.Add(donationConfiguration);

            //SMC
            donationConfiguration = CreateCoinConfiguration("SMC", "stratum+tcp://de3.miningpool.co", 9057);
            configurations.Add(donationConfiguration);

            //TEA
            donationConfiguration = CreateCoinConfiguration("TEA", "stratum+tcp://de3.miningpool.co", 3921);
            configurations.Add(donationConfiguration);

            //NEC
            donationConfiguration = CreateCoinConfiguration("NEC", "stratum+tcp://neo.cryptcoins.net", 3331);
            configurations.Add(donationConfiguration);

            //TAG
            donationConfiguration = CreateCoinConfiguration("TAG", "stratum+tcp://tag.hashfaster.com", 3335);
            configurations.Add(donationConfiguration);
        }

        private static Data.Configuration.Coin CreateCoinConfiguration(string coinSymbol, string host, int port, string username = "nwoolls.mmdonations")
        {
            Data.Configuration.Coin donationConfiguration = new Data.Configuration.Coin();
            donationConfiguration.CryptoCoin.Symbol = coinSymbol;

            MiningPool donationPool = new MiningPool()
            {
                Host = host,
                Port = port,
                Username = username,
                Password = "X"
            };
            donationConfiguration.Pools.Add(donationPool);

            return donationConfiguration;
        }
    }
}