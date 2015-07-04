using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using Utility;
using CsvHelper;
using CsvHelper.Configuration;

namespace DataEntryFirstStep
{
    class MergerCsv
    {
        private ArrayList CsvFilesPath = new ArrayList();

        private List<string> FirstLine = new List<string>();

        private string _strBatchResult = "";

        public MergerCsv(string strDir, string CsvName)
        {
            _strBatchResult += strDir + "\\result\\" + CsvName;
            if (!Directory.Exists(strDir + "\\result\\"))
            {
                Directory.CreateDirectory(strDir + "\\result\\");
            }
            if (File.Exists(_strBatchResult))
            {
                File.Delete(_strBatchResult);
            }

            CsvFilesPath = DirectoryReader.GetFiles(strDir, "*.csv", false);

            foreach (string item in CsvFilesPath)
            {
                Console.WriteLine(item);
            }
        }

        public void MergerToOneCsv()
        {
            bool b = true;

            foreach (string item in CsvFilesPath)
            {
                using (var reader = new CsvReader(new StreamReader(item)))
                {
                    if (FirstLine.Count <= 0)
                    {
                        reader.Read();
                        FirstLine = new List<string>(reader.FieldHeaders);
                    }
                    if (b)
                    {
                        using (var writer = new CsvWriter(new StreamWriter(_strBatchResult, true)))
                        {
                            foreach (string s in FirstLine)
                            {
                                writer.WriteField(s);
                            }
                            writer.NextRecord();
                            foreach (string s in FirstLine)
                            {
                                writer.WriteField(reader.GetField(s));
                            }
                            writer.NextRecord();
                        }
                        b = false;
                    }

                    while (reader.Read())
                    {
                        using (var writer = new CsvWriter(new StreamWriter(_strBatchResult, true)))
                        {
                            foreach (string strHeader in reader.FieldHeaders)
                            {
                                Console.WriteLine(reader.GetField(strHeader));
                            }
                            foreach (string s in FirstLine)
                            {
                                writer.WriteField(reader.GetField(s));
                            }
                            writer.NextRecord();
                        }

                    }
                }
            }
        }


    }

    class Record
    {
        [CsvField]
        public string DocFileName { get; set; }
        public string DocumentType { get; set; }
        public string CODFISC { get; set; }
        public string CODFISC_COO { get; set; }
        public string COD_IDENT { get; set; }
        public string CHKANNO { get; set; }
        public string RAGSOC { get; set; }
        public string NOME { get; set; }
        public string DATANASC { get; set; }
        public string SESSO { get; set; }
        public string COMNASC { get; set; }
        public string PROV { get; set; }
        public string COMFISC { get; set; }
        public string PROVFISC { get; set; }
        public string INDFISC { get; set; }
        public string ER_CODT1 { get; set; }
        public string ER_RARP1 { get; set; }
        public string ER_ANNO1 { get; set; }
        public string ER_IMPA1 { get; set; }
        public string ER_IMPB1 { get; set; }
        public string ER_CODT2 { get; set; }
        public string ER_RARP2 { get; set; }
        public string ER_ANNO2 { get; set; }
        public string ER_IMPA2 { get; set; }
        public string ER_IMPB2 { get; set; }
        public string ER_CODT3 { get; set; }
        public string ER_RARP3 { get; set; }
        public string ER_ANNO3 { get; set; }
        public string ER_IMPA3 { get; set; }
        public string ER_IMPB3 { get; set; }
        public string ER_CODT4 { get; set; }
        public string ER_RARP4 { get; set; }
        public string ER_ANNO4 { get; set; }
        public string ER_IMPA4 { get; set; }
        public string ER_IMPB4 { get; set; }
        public string ER_CODT5 { get; set; }
        public string ER_RARP5 { get; set; }
        public string ER_ANNO5 { get; set; }
        public string ER_IMPA5 { get; set; }
        public string ER_IMPB5 { get; set; }
        public string ER_CODT6 { get; set; }
        public string ER_RARP6 { get; set; }
        public string ER_ANNO6 { get; set; }
        public string ER_IMPA6 { get; set; }
        public string ER_IMPB6 { get; set; }
        public string CODUFF { get; set; }
        public string CODATTO { get; set; }
        public string ER_TOTA { get; set; }
        public string ER_TOTB { get; set; }
        public string ER_SALDO { get; set; }
        public string IN_SEDE1 { get; set; }
        public string IN_CAUS1 { get; set; }
        public string IN_MATR1 { get; set; }
        public string IN_PERD1 { get; set; }
        public string IN_PERA1 { get; set; }
        public string IN_IMPC1 { get; set; }
        public string IN_IMPD1 { get; set; }
        public string IN_SEDE2 { get; set; }
        public string IN_CAUS2 { get; set; }
        public string IN_MATR2 { get; set; }
        public string IN_PERD2 { get; set; }
        public string IN_PERA2 { get; set; }
        public string IN_IMPC2 { get; set; }
        public string IN_IMPD2 { get; set; }
        public string IN_SEDE3 { get; set; }
        public string IN_CAUS3 { get; set; }
        public string IN_MATR3 { get; set; }
        public string IN_PERD3 { get; set; }
        public string IN_PERA3 { get; set; }
        public string IN_IMPC3 { get; set; }
        public string IN_IMPD3 { get; set; }
        public string IN_SEDE4 { get; set; }
        public string IN_CAUS4 { get; set; }
        public string IN_MATR4 { get; set; }
        public string IN_PERD4 { get; set; }
        public string IN_PERA4 { get; set; }
        public string IN_IMPC4 { get; set; }
        public string IN_IMPD4 { get; set; }
        public string IN_TOTC { get; set; }
        public string IN_TOTD { get; set; }
        public string IN_SALDO { get; set; }
        public string RE_CREG1 { get; set; }
        public string RE_CTRI1 { get; set; }
        public string RE_RATE1 { get; set; }
        public string RE_ANNO1 { get; set; }
        public string RE_IMPE1 { get; set; }
        public string RE_IMPF1 { get; set; }
        public string RE_CREG2 { get; set; }
        public string RE_CTRI2 { get; set; }
        public string RE_RATE2 { get; set; }
        public string RE_ANNO2 { get; set; }
        public string RE_IMPE2 { get; set; }
        public string RE_IMPF2 { get; set; }
        public string RE_CREG3 { get; set; }
        public string RE_CTRI3 { get; set; }
        public string RE_RATE3 { get; set; }
        public string RE_ANNO3 { get; set; }
        public string RE_IMPE3 { get; set; }
        public string RE_IMPF3 { get; set; }
        public string RE_CREG4 { get; set; }
        public string RE_CTRI4 { get; set; }
        public string RE_RATE4 { get; set; }
        public string RE_ANNO4 { get; set; }
        public string RE_IMPE4 { get; set; }
        public string RE_IMPF4 { get; set; }
        public string RE_TOTE { get; set; }
        public string RE_TOTF { get; set; }
        public string RE_SALDO { get; set; }
        public string IC_CCOM1 { get; set; }
        public string IC_F11 { get; set; }
        public string IC_F21 { get; set; }
        public string IC_F31 { get; set; }
        public string IC_F41 { get; set; }
        public string IC_NFAB1 { get; set; }
        public string IC_CTRI1 { get; set; }
        public string IC_RATE1 { get; set; }
        public string IC_ANNO1 { get; set; }
        public string IC_IMPG1 { get; set; }
        public string IC_IMPH1 { get; set; }
        public string IC_CCOM2 { get; set; }
        public string IC_F12 { get; set; }
        public string IC_F22 { get; set; }
        public string IC_F32 { get; set; }
        public string IC_F42 { get; set; }
        public string IC_NFAB2 { get; set; }
        public string IC_CTRI2 { get; set; }
        public string IC_RATE2 { get; set; }
        public string IC_ANNO2 { get; set; }
        public string IC_IMPG2 { get; set; }
        public string IC_IMPH2 { get; set; }
        public string IC_CCOM3 { get; set; }
        public string IC_F13 { get; set; }
        public string IC_F23 { get; set; }
        public string IC_F33 { get; set; }
        public string IC_F43 { get; set; }
        public string IC_NFAB3 { get; set; }
        public string IC_CTRI3 { get; set; }
        public string IC_RATE3 { get; set; }
        public string IC_ANNO3 { get; set; }
        public string IC_IMPG3 { get; set; }
        public string IC_IMPH3 { get; set; }
        public string IC_CCOM4 { get; set; }
        public string IC_F14 { get; set; }
        public string IC_F24 { get; set; }
        public string IC_F34 { get; set; }
        public string IC_F44 { get; set; }
        public string IC_NFAB4 { get; set; }
        public string IC_CTRI4 { get; set; }
        public string IC_RATE4 { get; set; }
        public string IC_ANNO4 { get; set; }
        public string IC_IMPG4 { get; set; }
        public string IC_IMPH4 { get; set; }
        public string IC_TOTG { get; set; }
        public string IC_TOTH { get; set; }
        public string IC_SALDO { get; set; }
        public string IC_DETR { get; set; }
        public string AL_CODS1 { get; set; }
        public string AL_NUME1 { get; set; }
        public string AL_CC1 { get; set; }
        public string AL_NRIF1 { get; set; }
        public string AL_CAUS1 { get; set; }
        public string AL_IMPI1 { get; set; }
        public string AL_IMPL1 { get; set; }
        public string AL_CODS2 { get; set; }
        public string AL_NUME2 { get; set; }
        public string AL_CC2 { get; set; }
        public string AL_NRIF2 { get; set; }
        public string AL_CAUS2 { get; set; }
        public string AL_IMPI2 { get; set; }
        public string AL_IMPL2 { get; set; }
        public string AL_CODS3 { get; set; }
        public string AL_NUME3 { get; set; }
        public string AL_CC3 { get; set; }
        public string AL_NRIF3 { get; set; }
        public string AL_CAUS3 { get; set; }
        public string AL_IMPI3 { get; set; }
        public string AL_IMPL3 { get; set; }
        public string AL_TOTI { get; set; }
        public string AL_TOTL { get; set; }
        public string AL_SALDO { get; set; }
        public string AL1_CENT { get; set; }
        public string AL1_CSED1 { get; set; }
        public string AL1_CCON1 { get; set; }
        public string AL1_CPOS1 { get; set; }
        public string AL1_PERD1 { get; set; }
        public string AL1_PERA1 { get; set; }
        public string AL1_IMPM1 { get; set; }
        public string AL1_IMPN1 { get; set; }
        public string AL1_CSED2 { get; set; }
        public string AL1_CCON2 { get; set; }
        public string AL1_CPOS2 { get; set; }
        public string AL1_PERD2 { get; set; }
        public string AL1_PERA2 { get; set; }
        public string AL1_IMPM2 { get; set; }
        public string AL1_IMPN2 { get; set; }
        public string AL1_TOTM { get; set; }
        public string AL1_TOTN { get; set; }
        public string AL1_SALDO { get; set; }
        public string AC_ENTE1 { get; set; }
        public string AC_PROV1 { get; set; }
        public string AC_TRIB1 { get; set; }
        public string AC_IDEN1 { get; set; }
        public string AC_RATE1 { get; set; }
        public string AC_RIFE1 { get; set; }
        public string AC_IMPV1 { get; set; }
        public string AC_ENTE2 { get; set; }
        public string AC_PROV2 { get; set; }
        public string AC_TRIB2 { get; set; }
        public string AC_IDEN2 { get; set; }
        public string AC_RATE2 { get; set; }
        public string AC_RIFE2 { get; set; }
        public string AC_IMPV2 { get; set; }
        public string AC_ENTE3 { get; set; }
        public string AC_PROV3 { get; set; }
        public string AC_TRIB3 { get; set; }
        public string AC_IDEN3 { get; set; }
        public string AC_RATE3 { get; set; }
        public string AC_RIFE3 { get; set; }
        public string AC_IMPV3 { get; set; }
        public string AC_ENTE4 { get; set; }
        public string AC_PROV4 { get; set; }
        public string AC_TRIB4 { get; set; }
        public string AC_IDEN4 { get; set; }
        public string AC_RATE4 { get; set; }
        public string AC_RIFE4 { get; set; }
        public string AC_IMPV4 { get; set; }
        public string AC_ENTE5 { get; set; }
        public string AC_PROV5 { get; set; }
        public string AC_TRIB5 { get; set; }
        public string AC_IDEN5 { get; set; }
        public string AC_RATE5 { get; set; }
        public string AC_RIFE5 { get; set; }
        public string AC_IMPV5 { get; set; }
        public string AC_ENTE6 { get; set; }
        public string AC_PROV6 { get; set; }
        public string AC_TRIB6 { get; set; }
        public string AC_IDEN6 { get; set; }
        public string AC_RATE6 { get; set; }
        public string AC_RIFE6 { get; set; }
        public string AC_IMPV6 { get; set; }
        public string AC_ENTE7 { get; set; }
        public string AC_PROV7 { get; set; }
        public string AC_TRIB7 { get; set; }
        public string AC_IDEN7 { get; set; }
        public string AC_RATE7 { get; set; }
        public string AC_RIFE7 { get; set; }
        public string AC_IMPV7 { get; set; }
        public string AC_CODUFF { get; set; }
        public string AC_CODATTO { get; set; }
        public string AC_TOTO { get; set; }
        public string AC_TOTP { get; set; }
        public string AC_SALDO { get; set; }
        public string EI_CODUFF { get; set; }
        public string EI_CODATTO { get; set; }
        public string EI_TIPO1 { get; set; }
        public string EI_ELE_IDE1 { get; set; }
        public string EI_TRI1 { get; set; }
        public string EI_ANNO1 { get; set; }
        public string EI_IMPORTO1 { get; set; }
        public string EI_TIPO2 { get; set; }
        public string EI_ELE_IDE2 { get; set; }
        public string EI_TRI2 { get; set; }
        public string EI_ANNO2 { get; set; }
        public string EI_IMPORTO2 { get; set; }
        public string EI_TIPO3 { get; set; }
        public string EI_ELE_IDE3 { get; set; }
        public string EI_TRI3 { get; set; }
        public string EI_ANNO3 { get; set; }
        public string EI_IMPORTO3 { get; set; }
        public string EI_TIPO4 { get; set; }
        public string EI_ELE_IDE4 { get; set; }
        public string EI_TRI4 { get; set; }
        public string EI_ANNO4 { get; set; }
        public string EI_IMPORTO4 { get; set; }
        public string EI_TIPO5 { get; set; }
        public string EI_ELE_IDE5 { get; set; }
        public string EI_TRI5 { get; set; }
        public string EI_ANNO5 { get; set; }
        public string EI_IMPORTO5 { get; set; }
        public string EI_TIPO6 { get; set; }
        public string EI_ELE_IDE6 { get; set; }
        public string EI_TRI6 { get; set; }
        public string EI_ANNO6 { get; set; }
        public string EI_IMPORTO6 { get; set; }
        public string EI_TIPO7 { get; set; }
        public string EI_ELE_IDE7 { get; set; }
        public string EI_TRI7 { get; set; }
        public string EI_ANNO7 { get; set; }
        public string EI_IMPORTO7 { get; set; }
        public string EI_TIPO8 { get; set; }
        public string EI_ELE_IDE8 { get; set; }
        public string EI_TRI8 { get; set; }
        public string EI_ANNO8 { get; set; }
        public string EI_IMPORTO8 { get; set; }
        public string EI_TIPO9 { get; set; }
        public string EI_ELE_IDE9 { get; set; }
        public string EI_TRI9 { get; set; }
        public string EI_ANNO9 { get; set; }
        public string EI_IMPORTO9 { get; set; }
        public string EI_TIPO10 { get; set; }
        public string EI_ELE_IDE10 { get; set; }
        public string EI_TRI10 { get; set; }
        public string EI_ANNO10 { get; set; }
        public string EI_IMPORTO10 { get; set; }
        public string EI_TIPO11 { get; set; }
        public string EI_ELE_IDE11 { get; set; }
        public string EI_TRI11 { get; set; }
        public string EI_ANNO11 { get; set; }
        public string EI_IMPORTO11 { get; set; }
        public string EI_TIPO12 { get; set; }
        public string EI_ELE_IDE12 { get; set; }
        public string EI_TRI12 { get; set; }
        public string EI_ANNO12 { get; set; }
        public string EI_IMPORTO12 { get; set; }
        public string EI_TIPO13 { get; set; }
        public string EI_ELE_IDE13 { get; set; }
        public string EI_TRI13 { get; set; }
        public string EI_ANNO13 { get; set; }
        public string EI_IMPORTO13 { get; set; }
        public string EI_TIPO14 { get; set; }
        public string EI_ELE_IDE14 { get; set; }
        public string EI_TRI14 { get; set; }
        public string EI_ANNO14 { get; set; }
        public string EI_IMPORTO14 { get; set; }
        public string EI_TIPO15 { get; set; }
        public string EI_ELE_IDE15 { get; set; }
        public string EI_TRI15 { get; set; }
        public string EI_ANNO15 { get; set; }
        public string EI_IMPORTO15 { get; set; }
        public string EI_TIPO16 { get; set; }
        public string EI_ELE_IDE16 { get; set; }
        public string EI_TRI16 { get; set; }
        public string EI_ANNO16 { get; set; }
        public string EI_IMPORTO16 { get; set; }
        public string EI_TIPO17 { get; set; }
        public string EI_ELE_IDE17 { get; set; }
        public string EI_TRI17 { get; set; }
        public string EI_ANNO17 { get; set; }
        public string EI_IMPORTO17 { get; set; }
        public string EI_TIPO18 { get; set; }
        public string EI_ELE_IDE18 { get; set; }
        public string EI_TRI18 { get; set; }
        public string EI_ANNO18 { get; set; }
        public string EI_IMPORTO18 { get; set; }
        public string EI_TIPO19 { get; set; }
        public string EI_ELE_IDE19 { get; set; }
        public string EI_TRI19 { get; set; }
        public string EI_ANNO19 { get; set; }
        public string EI_IMPORTO19 { get; set; }
        public string EI_TIPO20 { get; set; }
        public string EI_ELE_IDE20 { get; set; }
        public string EI_TRI20 { get; set; }
        public string EI_ANNO20 { get; set; }
        public string EI_IMPORTO20 { get; set; }
        public string EI_TIPO21 { get; set; }
        public string EI_ELE_IDE21 { get; set; }
        public string EI_TRI21 { get; set; }
        public string EI_ANNO21 { get; set; }
        public string EI_IMPORTO21 { get; set; }
        public string EI_TIPO22 { get; set; }
        public string EI_ELE_IDE22 { get; set; }
        public string EI_TRI22 { get; set; }
        public string EI_ANNO22 { get; set; }
        public string EI_IMPORTO22 { get; set; }
        public string EI_TIPO23 { get; set; }
        public string EI_ELE_IDE23 { get; set; }
        public string EI_TRI23 { get; set; }
        public string EI_ANNO23 { get; set; }
        public string EI_IMPORTO23 { get; set; }
        public string EI_TIPO24 { get; set; }
        public string EI_ELE_IDE24 { get; set; }
        public string EI_TRI24 { get; set; }
        public string EI_ANNO24 { get; set; }
        public string EI_IMPORTO24 { get; set; }
        public string EI_TIPO25 { get; set; }
        public string EI_ELE_IDE25 { get; set; }
        public string EI_TRI25 { get; set; }
        public string EI_ANNO25 { get; set; }
        public string EI_IMPORTO25 { get; set; }
        public string EI_TIPO26 { get; set; }
        public string EI_ELE_IDE26 { get; set; }
        public string EI_TRI26 { get; set; }
        public string EI_ANNO26 { get; set; }
        public string EI_IMPORTO26 { get; set; }
        public string EI_TIPO27 { get; set; }
        public string EI_ELE_IDE27 { get; set; }
        public string EI_TRI27 { get; set; }
        public string EI_ANNO27 { get; set; }
        public string EI_IMPORTO27 { get; set; }
        public string EI_TIPO28 { get; set; }
        public string EI_ELE_IDE28 { get; set; }
        public string EI_TRI28 { get; set; }
        public string EI_ANNO28 { get; set; }
        public string EI_IMPORTO28 { get; set; }
        public string SE_SEZ1 { get; set; }
        public string SE_TRI1 { get; set; }
        public string SE_ENTE1 { get; set; }
        public string SE_F11 { get; set; }
        public string SE_F21 { get; set; }
        public string SE_F31 { get; set; }
        public string SE_F41 { get; set; }
        public string SE_NFAB1 { get; set; }
        public string SE_RATE1 { get; set; }
        public string SE_ANNO1 { get; set; }
        public string SE_DETR1 { get; set; }
        public string SE_IMPV1 { get; set; }
        public string SE_IMPC1 { get; set; }
        public string SE_SEZ2 { get; set; }
        public string SE_TRI2 { get; set; }
        public string SE_ENTE2 { get; set; }
        public string SE_F12 { get; set; }
        public string SE_F22 { get; set; }
        public string SE_F32 { get; set; }
        public string SE_F42 { get; set; }
        public string SE_NFAB2 { get; set; }
        public string SE_RATE2 { get; set; }
        public string SE_ANNO2 { get; set; }
        public string SE_DETR2 { get; set; }
        public string SE_IMPV2 { get; set; }
        public string SE_IMPC2 { get; set; }
        public string SE_SEZ3 { get; set; }
        public string SE_TRI3 { get; set; }
        public string SE_ENTE3 { get; set; }
        public string SE_F13 { get; set; }
        public string SE_F23 { get; set; }
        public string SE_F33 { get; set; }
        public string SE_F43 { get; set; }
        public string SE_NFAB3 { get; set; }
        public string SE_RATE3 { get; set; }
        public string SE_ANNO3 { get; set; }
        public string SE_DETR3 { get; set; }
        public string SE_IMPV3 { get; set; }
        public string SE_IMPC3 { get; set; }
        public string SE_SEZ4 { get; set; }
        public string SE_TRI4 { get; set; }
        public string SE_ENTE4 { get; set; }
        public string SE_F14 { get; set; }
        public string SE_F24 { get; set; }
        public string SE_F34 { get; set; }
        public string SE_F44 { get; set; }
        public string SE_NFAB4 { get; set; }
        public string SE_RATE4 { get; set; }
        public string SE_ANNO4 { get; set; }
        public string SE_DETR4 { get; set; }
        public string SE_IMPV4 { get; set; }
        public string SE_IMPC4 { get; set; }
        public string SE_SEZ5 { get; set; }
        public string SE_TRI5 { get; set; }
        public string SE_ENTE5 { get; set; }
        public string SE_F15 { get; set; }
        public string SE_F25 { get; set; }
        public string SE_F35 { get; set; }
        public string SE_F45 { get; set; }
        public string SE_NFAB5 { get; set; }
        public string SE_RATE5 { get; set; }
        public string SE_ANNO5 { get; set; }
        public string SE_DETR5 { get; set; }
        public string SE_IMPV5 { get; set; }
        public string SE_IMPC5 { get; set; }
        public string SE_SEZ6 { get; set; }
        public string SE_TRI6 { get; set; }
        public string SE_ENTE6 { get; set; }
        public string SE_F16 { get; set; }
        public string SE_F26 { get; set; }
        public string SE_F36 { get; set; }
        public string SE_F46 { get; set; }
        public string SE_NFAB6 { get; set; }
        public string SE_RATE6 { get; set; }
        public string SE_ANNO6 { get; set; }
        public string SE_DETR6 { get; set; }
        public string SE_IMPV6 { get; set; }
        public string SE_IMPC6 { get; set; }
        public string SE_SEZ7 { get; set; }
        public string SE_TRI7 { get; set; }
        public string SE_ENTE7 { get; set; }
        public string SE_F17 { get; set; }
        public string SE_F27 { get; set; }
        public string SE_F37 { get; set; }
        public string SE_F47 { get; set; }
        public string SE_NFAB7 { get; set; }
        public string SE_RATE7 { get; set; }
        public string SE_ANNO7 { get; set; }
        public string SE_DETR7 { get; set; }
        public string SE_IMPV7 { get; set; }
        public string SE_IMPC7 { get; set; }
        public string SE_SEZ8 { get; set; }
        public string SE_TRI8 { get; set; }
        public string SE_ENTE8 { get; set; }
        public string SE_F18 { get; set; }
        public string SE_F28 { get; set; }
        public string SE_F38 { get; set; }
        public string SE_F48 { get; set; }
        public string SE_NFAB8 { get; set; }
        public string SE_RATE8 { get; set; }
        public string SE_ANNO8 { get; set; }
        public string SE_DETR8 { get; set; }
        public string SE_IMPV8 { get; set; }
        public string SE_IMPC8 { get; set; }
        public string SE_SEZ9 { get; set; }
        public string SE_TRI9 { get; set; }
        public string SE_ENTE9 { get; set; }
        public string SE_F19 { get; set; }
        public string SE_F29 { get; set; }
        public string SE_F39 { get; set; }
        public string SE_F49 { get; set; }
        public string SE_NFAB9 { get; set; }
        public string SE_RATE9 { get; set; }
        public string SE_ANNO9 { get; set; }
        public string SE_DETR9 { get; set; }
        public string SE_IMPV9 { get; set; }
        public string SE_IMPC9 { get; set; }
        public string SE_SEZ10 { get; set; }
        public string SE_TRI10 { get; set; }
        public string SE_ENTE10 { get; set; }
        public string SE_F110 { get; set; }
        public string SE_F210 { get; set; }
        public string SE_F310 { get; set; }
        public string SE_F410 { get; set; }
        public string SE_NFAB10 { get; set; }
        public string SE_RATE10 { get; set; }
        public string SE_ANNO10 { get; set; }
        public string SE_DETR10 { get; set; }
        public string SE_IMPV10 { get; set; }
        public string SE_IMPC10 { get; set; }
        public string TOTGEN { get; set; }
        public string PRE_IDENTI { get; set; }
        public string PRE_IMPORTO { get; set; }
        public string Quality { get; set; }
    }
}
