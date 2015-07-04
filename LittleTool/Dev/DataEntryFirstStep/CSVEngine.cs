using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using CsvHelper;
using CsvHelper.Configuration;

namespace DataEntryFirstStep
{
    public class ResultDataFormat
    {
        public string strNameInCode;
        public string strNameFromCustom;
        public string strOCRResult;
    }
    public class CSVResult
    {

        public List<ResultDataFormat> result = new List<ResultDataFormat>();
        private static CSVResult instance;
        private CSVResult()
        {
            result.Add(InitCSVFormat("", "DocFileName"));
            result.Add(InitCSVFormat("", "DocumentType"));
            result.Add(InitCSVFormat("ClassifyFlag", "ClassifyFlag"));
            result.Add(InitCSVFormat("TaxCodeQuality", "TaxCodeQuality"));
            result.Add(InitCSVFormat("S1_1_1", "CODFISC"));
            result.Add(InitCSVFormat("S1_5_1", "CODFISC_COO"));
            result.Add(InitCSVFormat("S1_5_2", "COD_IDENT"));
            result.Add(InitCSVFormat("S1_1_2", "CHKANNO"));
            result.Add(InitCSVFormat("S1_2_1", "RAGSOC"));
            result.Add(InitCSVFormat("S1_2_2", "NOME"));
            result.Add(InitCSVFormat("S1_3_1", "DATANASC"));
            result.Add(InitCSVFormat("S1_3_2", "SESSO"));
            result.Add(InitCSVFormat("S1_3_3", "COMNASC"));
            result.Add(InitCSVFormat("S1_3_4", "PROV"));
            result.Add(InitCSVFormat("S1_4_1", "COMFISC"));
            result.Add(InitCSVFormat("S1_4_2", "PROVFISC"));
            result.Add(InitCSVFormat("S1_4_3", "INDFISC"));



            result.Add(InitCSVFormat("S2_1_1", "ER_CODT1"));
            result.Add(InitCSVFormat("S2_1_2", "ER_RARP1"));
            result.Add(InitCSVFormat("S2_1_3", "ER_ANNO1"));
            result.Add(InitCSVFormat("S2_1_4", "ER_IMPA1"));
            result.Add(InitCSVFormat("S2_1_5", "ER_IMPB1"));
            result.Add(InitCSVFormat("S2_2_1", "ER_CODT2"));
            result.Add(InitCSVFormat("S2_2_2", "ER_RARP2"));
            result.Add(InitCSVFormat("S2_2_3", "ER_ANNO2"));
            result.Add(InitCSVFormat("S2_2_4", "ER_IMPA2"));
            result.Add(InitCSVFormat("S2_2_5", "ER_IMPB2"));
            result.Add(InitCSVFormat("S2_3_1", "ER_CODT3"));
            result.Add(InitCSVFormat("S2_3_2", "ER_RARP3"));
            result.Add(InitCSVFormat("S2_3_3", "ER_ANNO3"));
            result.Add(InitCSVFormat("S2_3_4", "ER_IMPA3"));
            result.Add(InitCSVFormat("S2_3_5", "ER_IMPB3"));
            result.Add(InitCSVFormat("S2_4_1", "ER_CODT4"));
            result.Add(InitCSVFormat("S2_4_2", "ER_RARP4"));
            result.Add(InitCSVFormat("S2_4_3", "ER_ANNO4"));
            result.Add(InitCSVFormat("S2_4_4", "ER_IMPA4"));
            result.Add(InitCSVFormat("S2_4_5", "ER_IMPB4"));
            result.Add(InitCSVFormat("S2_5_1", "ER_CODT5"));
            result.Add(InitCSVFormat("S2_5_2", "ER_RARP5"));
            result.Add(InitCSVFormat("S2_5_3", "ER_ANNO5"));
            result.Add(InitCSVFormat("S2_5_4", "ER_IMPA5"));
            result.Add(InitCSVFormat("S2_5_5", "ER_IMPB5"));
            result.Add(InitCSVFormat("S2_6_1", "ER_CODT6"));
            result.Add(InitCSVFormat("S2_6_2", "ER_RARP6"));
            result.Add(InitCSVFormat("S2_6_3", "ER_ANNO6"));
            result.Add(InitCSVFormat("S2_6_4", "ER_IMPA6"));
            result.Add(InitCSVFormat("S2_6_5", "ER_IMPB6"));

            result.Add(InitCSVFormat("S2_7_1", "CODUFF"));
            result.Add(InitCSVFormat("S2_7_2", "CODATTO"));

            result.Add(InitCSVFormat("S2_7_3", "ER_TOTA"));
            result.Add(InitCSVFormat("S2_7_4", "ER_TOTB"));
            result.Add(InitCSVFormat("S2_7_5", "ER_SALDO"));
            result.Add(InitCSVFormat("S3_1_1", "IN_SEDE1"));
            result.Add(InitCSVFormat("S3_1_2", "IN_CAUS1"));
            result.Add(InitCSVFormat("S3_1_3", "IN_MATR1"));
            result.Add(InitCSVFormat("S3_1_4", "IN_PERD1"));
            result.Add(InitCSVFormat("S3_1_5", "IN_PERA1"));
            result.Add(InitCSVFormat("S3_1_6", "IN_IMPC1"));
            result.Add(InitCSVFormat("S3_1_7", "IN_IMPD1"));
            result.Add(InitCSVFormat("S3_2_1", "IN_SEDE2"));
            result.Add(InitCSVFormat("S3_2_2", "IN_CAUS2"));
            result.Add(InitCSVFormat("S3_2_3", "IN_MATR2"));
            result.Add(InitCSVFormat("S3_2_4", "IN_PERD2"));
            result.Add(InitCSVFormat("S3_2_5", "IN_PERA2"));
            result.Add(InitCSVFormat("S3_2_6", "IN_IMPC2"));
            result.Add(InitCSVFormat("S3_2_7", "IN_IMPD2"));
            result.Add(InitCSVFormat("S3_3_1", "IN_SEDE3"));
            result.Add(InitCSVFormat("S3_3_2", "IN_CAUS3"));
            result.Add(InitCSVFormat("S3_3_3", "IN_MATR3"));
            result.Add(InitCSVFormat("S3_3_4", "IN_PERD3"));
            result.Add(InitCSVFormat("S3_3_5", "IN_PERA3"));
            result.Add(InitCSVFormat("S3_3_6", "IN_IMPC3"));
            result.Add(InitCSVFormat("S3_3_7", "IN_IMPD3"));
            result.Add(InitCSVFormat("S3_4_1", "IN_SEDE4"));
            result.Add(InitCSVFormat("S3_4_2", "IN_CAUS4"));
            result.Add(InitCSVFormat("S3_4_3", "IN_MATR4"));
            result.Add(InitCSVFormat("S3_4_4", "IN_PERD4"));
            result.Add(InitCSVFormat("S3_4_5", "IN_PERA4"));
            result.Add(InitCSVFormat("S3_4_6", "IN_IMPC4"));
            result.Add(InitCSVFormat("S3_4_7", "IN_IMPD4"));
            result.Add(InitCSVFormat("S3_5_1", "IN_TOTC"));
            result.Add(InitCSVFormat("S3_5_2", "IN_TOTD"));
            result.Add(InitCSVFormat("S3_5_3", "IN_SALDO"));
            result.Add(InitCSVFormat("S4_1_1", "RE_CREG1"));
            result.Add(InitCSVFormat("S4_1_2", "RE_CTRI1"));
            result.Add(InitCSVFormat("S4_1_3", "RE_RATE1"));
            result.Add(InitCSVFormat("S4_1_4", "RE_ANNO1"));
            result.Add(InitCSVFormat("S4_1_5", "RE_IMPE1"));
            result.Add(InitCSVFormat("S4_1_6", "RE_IMPF1"));
            result.Add(InitCSVFormat("S4_2_1", "RE_CREG2"));
            result.Add(InitCSVFormat("S4_2_2", "RE_CTRI2"));
            result.Add(InitCSVFormat("S4_2_3", "RE_RATE2"));
            result.Add(InitCSVFormat("S4_2_4", "RE_ANNO2"));
            result.Add(InitCSVFormat("S4_2_5", "RE_IMPE2"));
            result.Add(InitCSVFormat("S4_2_6", "RE_IMPF2"));
            result.Add(InitCSVFormat("S4_3_1", "RE_CREG3"));
            result.Add(InitCSVFormat("S4_3_2", "RE_CTRI3"));
            result.Add(InitCSVFormat("S4_3_3", "RE_RATE3"));
            result.Add(InitCSVFormat("S4_3_4", "RE_ANNO3"));
            result.Add(InitCSVFormat("S4_3_5", "RE_IMPE3"));
            result.Add(InitCSVFormat("S4_3_6", "RE_IMPF3"));
            result.Add(InitCSVFormat("S4_4_1", "RE_CREG4"));
            result.Add(InitCSVFormat("S4_4_2", "RE_CTRI4"));
            result.Add(InitCSVFormat("S4_4_3", "RE_RATE4"));
            result.Add(InitCSVFormat("S4_4_4", "RE_ANNO4"));
            result.Add(InitCSVFormat("S4_4_5", "RE_IMPE4"));
            result.Add(InitCSVFormat("S4_4_6", "RE_IMPF4"));
            result.Add(InitCSVFormat("S4_5_1", "RE_TOTE"));
            result.Add(InitCSVFormat("S4_5_2", "RE_TOTF"));
            result.Add(InitCSVFormat("S4_5_3", "RE_SALDO"));
            result.Add(InitCSVFormat("S5_1_1", "IC_CCOM1"));
            result.Add(InitCSVFormat("S5_1_2", "IC_F11"));
            result.Add(InitCSVFormat("S5_1_3", "IC_F21"));
            result.Add(InitCSVFormat("S5_1_4", "IC_F31"));
            result.Add(InitCSVFormat("S5_1_5", "IC_F41"));
            result.Add(InitCSVFormat("S5_1_6", "IC_NFAB1"));
            result.Add(InitCSVFormat("S5_1_7", "IC_CTRI1"));
            result.Add(InitCSVFormat("S5_1_8", "IC_RATE1"));
            result.Add(InitCSVFormat("S5_1_9", "IC_ANNO1"));
            result.Add(InitCSVFormat("S5_1_10", "IC_IMPG1"));
            result.Add(InitCSVFormat("S5_1_11", "IC_IMPH1"));
            result.Add(InitCSVFormat("S5_2_1", "IC_CCOM2"));
            result.Add(InitCSVFormat("S5_2_2", "IC_F12"));
            result.Add(InitCSVFormat("S5_2_3", "IC_F22"));
            result.Add(InitCSVFormat("S5_2_4", "IC_F32"));
            result.Add(InitCSVFormat("S5_2_5", "IC_F42"));
            result.Add(InitCSVFormat("S5_2_6", "IC_NFAB2"));
            result.Add(InitCSVFormat("S5_2_7", "IC_CTRI2"));
            result.Add(InitCSVFormat("S5_2_8", "IC_RATE2"));
            result.Add(InitCSVFormat("S5_2_9", "IC_ANNO2"));
            result.Add(InitCSVFormat("S5_2_10", "IC_IMPG2"));
            result.Add(InitCSVFormat("S5_2_11", "IC_IMPH2"));
            result.Add(InitCSVFormat("S5_3_1", "IC_CCOM3"));
            result.Add(InitCSVFormat("S5_3_2", "IC_F13"));
            result.Add(InitCSVFormat("S5_3_3", "IC_F23"));
            result.Add(InitCSVFormat("S5_3_4", "IC_F33"));
            result.Add(InitCSVFormat("S5_3_5", "IC_F43"));
            result.Add(InitCSVFormat("S5_3_6", "IC_NFAB3"));
            result.Add(InitCSVFormat("S5_3_7", "IC_CTRI3"));
            result.Add(InitCSVFormat("S5_3_8", "IC_RATE3"));
            result.Add(InitCSVFormat("S5_3_9", "IC_ANNO3"));
            result.Add(InitCSVFormat("S5_3_10", "IC_IMPG3"));
            result.Add(InitCSVFormat("S5_3_11", "IC_IMPH3"));
            result.Add(InitCSVFormat("S5_4_1", "IC_CCOM4"));
            result.Add(InitCSVFormat("S5_4_2", "IC_F14"));
            result.Add(InitCSVFormat("S5_4_3", "IC_F24"));
            result.Add(InitCSVFormat("S5_4_4", "IC_F34"));
            result.Add(InitCSVFormat("S5_4_5", "IC_F44"));
            result.Add(InitCSVFormat("S5_4_6", "IC_NFAB4"));
            result.Add(InitCSVFormat("S5_4_7", "IC_CTRI4"));
            result.Add(InitCSVFormat("S5_4_8", "IC_RATE4"));
            result.Add(InitCSVFormat("S5_4_9", "IC_ANNO4"));
            result.Add(InitCSVFormat("S5_4_10", "IC_IMPG4"));
            result.Add(InitCSVFormat("S5_4_11", "IC_IMPH4"));
            result.Add(InitCSVFormat("S5_5_2", "IC_TOTG"));
            result.Add(InitCSVFormat("S5_5_3", "IC_TOTH"));
            result.Add(InitCSVFormat("S5_5_4", "IC_SALDO"));
            result.Add(InitCSVFormat("S5_5_1", "IC_DETR"));
            result.Add(InitCSVFormat("S6_1_1", "AL_CODS1"));
            result.Add(InitCSVFormat("S6_1_2", "AL_NUME1"));
            result.Add(InitCSVFormat("S6_1_3", "AL_CC1"));
            result.Add(InitCSVFormat("S6_1_4", "AL_NRIF1"));
            result.Add(InitCSVFormat("S6_1_5", "AL_CAUS1"));
            result.Add(InitCSVFormat("S6_1_6", "AL_IMPI1"));
            result.Add(InitCSVFormat("S6_1_7", "AL_IMPL1"));
            result.Add(InitCSVFormat("S6_2_1", "AL_CODS2"));
            result.Add(InitCSVFormat("S6_2_2", "AL_NUME2"));
            result.Add(InitCSVFormat("S6_2_3", "AL_CC2"));
            result.Add(InitCSVFormat("S6_2_4", "AL_NRIF2"));
            result.Add(InitCSVFormat("S6_2_5", "AL_CAUS2"));
            result.Add(InitCSVFormat("S6_2_6", "AL_IMPI2"));
            result.Add(InitCSVFormat("S6_2_7", "AL_IMPL2"));
            result.Add(InitCSVFormat("S6_3_1", "AL_CODS3"));
            result.Add(InitCSVFormat("S6_3_2", "AL_NUME3"));
            result.Add(InitCSVFormat("S6_3_3", "AL_CC3"));
            result.Add(InitCSVFormat("S6_3_4", "AL_NRIF3"));
            result.Add(InitCSVFormat("S6_3_5", "AL_CAUS3"));
            result.Add(InitCSVFormat("S6_3_6", "AL_IMPI3"));
            result.Add(InitCSVFormat("S6_3_7", "AL_IMPL3"));
            result.Add(InitCSVFormat("S6_4_1", "AL_TOTI"));
            result.Add(InitCSVFormat("S6_4_2", "AL_TOTL"));
            result.Add(InitCSVFormat("S6_4_3", "AL_SALDO"));
            result.Add(InitCSVFormat("S7_0_0", "AL1_CENT"));
            result.Add(InitCSVFormat("S7_1_1", "AL1_CSED1"));
            result.Add(InitCSVFormat("S7_1_2", "AL1_CCON1"));
            result.Add(InitCSVFormat("S7_1_3", "AL1_CPOS1"));
            result.Add(InitCSVFormat("S7_1_4", "AL1_PERD1"));
            result.Add(InitCSVFormat("S7_1_5", "AL1_PERA1"));
            result.Add(InitCSVFormat("S7_1_6", "AL1_IMPM1"));
            result.Add(InitCSVFormat("S7_1_7", "AL1_IMPN1"));
            result.Add(InitCSVFormat("S7_2_1", "AL1_CSED2"));
            result.Add(InitCSVFormat("S7_2_2", "AL1_CCON2"));
            result.Add(InitCSVFormat("S7_2_3", "AL1_CPOS2"));
            result.Add(InitCSVFormat("S7_2_4", "AL1_PERD2"));
            result.Add(InitCSVFormat("S7_2_5", "AL1_PERA2"));
            result.Add(InitCSVFormat("S7_2_6", "AL1_IMPM2"));
            result.Add(InitCSVFormat("S7_2_7", "AL1_IMPN2"));
            result.Add(InitCSVFormat("S7_3_1", "AL1_TOTM"));
            result.Add(InitCSVFormat("S7_3_2", "AL1_TOTN"));
            result.Add(InitCSVFormat("S7_3_3", "AL1_SALDO"));



            result.Add(InitCSVFormat("ES1_6_1", "EI_CODUFF"));
            result.Add(InitCSVFormat("ES1_6_2", "EI_CODATTO"));

            result.Add(InitCSVFormat("ES2_1_1", "EI_TIPO1"));
            result.Add(InitCSVFormat("ES2_1_2", "EI_ELE_IDE1"));
            result.Add(InitCSVFormat("ES2_1_3", "EI_TRI1"));
            result.Add(InitCSVFormat("ES2_1_4", "EI_ANNO1"));
            result.Add(InitCSVFormat("ES2_1_5", "EI_IMPORTO1"));

            result.Add(InitCSVFormat("ES2_2_1", "EI_TIPO2"));
            result.Add(InitCSVFormat("ES2_2_2", "EI_ELE_IDE2"));
            result.Add(InitCSVFormat("ES2_2_3", "EI_TRI2"));
            result.Add(InitCSVFormat("ES2_2_4", "EI_ANNO2"));
            result.Add(InitCSVFormat("ES2_2_5", "EI_IMPORTO2"));

            result.Add(InitCSVFormat("ES2_3_1", "EI_TIPO3"));
            result.Add(InitCSVFormat("ES2_3_2", "EI_ELE_IDE3"));
            result.Add(InitCSVFormat("ES2_3_3", "EI_TRI3"));
            result.Add(InitCSVFormat("ES2_3_4", "EI_ANNO3"));
            result.Add(InitCSVFormat("ES2_3_5", "EI_IMPORTO3"));

            result.Add(InitCSVFormat("ES2_4_1", "EI_TIPO4"));
            result.Add(InitCSVFormat("ES2_4_2", "EI_ELE_IDE4"));
            result.Add(InitCSVFormat("ES2_4_3", "EI_TRI4"));
            result.Add(InitCSVFormat("ES2_4_4", "EI_ANNO4"));
            result.Add(InitCSVFormat("ES2_4_5", "EI_IMPORTO4"));

            result.Add(InitCSVFormat("ES2_5_1", "EI_TIPO5"));
            result.Add(InitCSVFormat("ES2_5_2", "EI_ELE_IDE5"));
            result.Add(InitCSVFormat("ES2_5_3", "EI_TRI5"));
            result.Add(InitCSVFormat("ES2_5_4", "EI_ANNO5"));
            result.Add(InitCSVFormat("ES2_5_5", "EI_IMPORTO5"));

            result.Add(InitCSVFormat("ES2_6_1", "EI_TIPO6"));
            result.Add(InitCSVFormat("ES2_6_2", "EI_ELE_IDE6"));
            result.Add(InitCSVFormat("ES2_6_3", "EI_TRI6"));
            result.Add(InitCSVFormat("ES2_6_4", "EI_ANNO6"));
            result.Add(InitCSVFormat("ES2_6_5", "EI_IMPORTO6"));

            result.Add(InitCSVFormat("ES2_7_1", "EI_TIPO7"));
            result.Add(InitCSVFormat("ES2_7_2", "EI_ELE_IDE7"));
            result.Add(InitCSVFormat("ES2_7_3", "EI_TRI7"));
            result.Add(InitCSVFormat("ES2_7_4", "EI_ANNO7"));
            result.Add(InitCSVFormat("ES2_7_5", "EI_IMPORTO7"));

            result.Add(InitCSVFormat("ES2_8_1", "EI_TIPO8"));
            result.Add(InitCSVFormat("ES2_8_2", "EI_ELE_IDE8"));
            result.Add(InitCSVFormat("ES2_8_3", "EI_TRI8"));
            result.Add(InitCSVFormat("ES2_8_4", "EI_ANNO8"));
            result.Add(InitCSVFormat("ES2_8_5", "EI_IMPORTO8"));

            result.Add(InitCSVFormat("ES2_9_1", "EI_TIPO9"));
            result.Add(InitCSVFormat("ES2_9_2", "EI_ELE_IDE9"));
            result.Add(InitCSVFormat("ES2_9_3", "EI_TRI9"));
            result.Add(InitCSVFormat("ES2_9_4", "EI_ANNO9"));
            result.Add(InitCSVFormat("ES2_9_5", "EI_IMPORTO9"));

            result.Add(InitCSVFormat("ES2_10_1", "EI_TIPO10"));
            result.Add(InitCSVFormat("ES2_10_2", "EI_ELE_IDE10"));
            result.Add(InitCSVFormat("ES2_10_3", "EI_TRI10"));
            result.Add(InitCSVFormat("ES2_10_4", "EI_ANNO10"));
            result.Add(InitCSVFormat("ES2_10_5", "EI_IMPORTO10"));

            result.Add(InitCSVFormat("ES2_11_1", "EI_TIPO11"));
            result.Add(InitCSVFormat("ES2_11_2", "EI_ELE_IDE11"));
            result.Add(InitCSVFormat("ES2_11_3", "EI_TRI11"));
            result.Add(InitCSVFormat("ES2_11_4", "EI_ANNO11"));
            result.Add(InitCSVFormat("ES2_11_5", "EI_IMPORTO11"));

            result.Add(InitCSVFormat("ES2_12_1", "EI_TIPO12"));
            result.Add(InitCSVFormat("ES2_12_2", "EI_ELE_IDE12"));
            result.Add(InitCSVFormat("ES2_12_3", "EI_TRI12"));
            result.Add(InitCSVFormat("ES2_12_4", "EI_ANNO12"));
            result.Add(InitCSVFormat("ES2_12_5", "EI_IMPORTO12"));

            result.Add(InitCSVFormat("ES2_13_1", "EI_TIPO13"));
            result.Add(InitCSVFormat("ES2_13_2", "EI_ELE_IDE13"));
            result.Add(InitCSVFormat("ES2_13_3", "EI_TRI13"));
            result.Add(InitCSVFormat("ES2_13_4", "EI_ANNO13"));
            result.Add(InitCSVFormat("ES2_13_5", "EI_IMPORTO13"));

            result.Add(InitCSVFormat("ES2_14_1", "EI_TIPO14"));
            result.Add(InitCSVFormat("ES2_14_2", "EI_ELE_IDE14"));
            result.Add(InitCSVFormat("ES2_14_3", "EI_TRI14"));
            result.Add(InitCSVFormat("ES2_14_4", "EI_ANNO14"));
            result.Add(InitCSVFormat("ES2_14_5", "EI_IMPORTO14"));

            result.Add(InitCSVFormat("ES2_15_1", "EI_TIPO15"));
            result.Add(InitCSVFormat("ES2_15_2", "EI_ELE_IDE15"));
            result.Add(InitCSVFormat("ES2_15_3", "EI_TRI15"));
            result.Add(InitCSVFormat("ES2_15_4", "EI_ANNO15"));
            result.Add(InitCSVFormat("ES2_15_5", "EI_IMPORTO15"));

            result.Add(InitCSVFormat("ES2_16_1", "EI_TIPO16"));
            result.Add(InitCSVFormat("ES2_16_2", "EI_ELE_IDE16"));
            result.Add(InitCSVFormat("ES2_16_3", "EI_TRI16"));
            result.Add(InitCSVFormat("ES2_16_4", "EI_ANNO16"));
            result.Add(InitCSVFormat("ES2_16_5", "EI_IMPORTO16"));

            result.Add(InitCSVFormat("ES2_17_1", "EI_TIPO17"));
            result.Add(InitCSVFormat("ES2_17_2", "EI_ELE_IDE17"));
            result.Add(InitCSVFormat("ES2_17_3", "EI_TRI17"));
            result.Add(InitCSVFormat("ES2_17_4", "EI_ANNO17"));
            result.Add(InitCSVFormat("ES2_17_5", "EI_IMPORTO17"));

            result.Add(InitCSVFormat("ES2_18_1", "EI_TIPO18"));
            result.Add(InitCSVFormat("ES2_18_2", "EI_ELE_IDE18"));
            result.Add(InitCSVFormat("ES2_18_3", "EI_TRI18"));
            result.Add(InitCSVFormat("ES2_18_4", "EI_ANNO18"));
            result.Add(InitCSVFormat("ES2_18_5", "EI_IMPORTO18"));

            result.Add(InitCSVFormat("ES2_19_1", "EI_TIPO19"));
            result.Add(InitCSVFormat("ES2_19_2", "EI_ELE_IDE19"));
            result.Add(InitCSVFormat("ES2_19_3", "EI_TRI19"));
            result.Add(InitCSVFormat("ES2_19_4", "EI_ANNO19"));
            result.Add(InitCSVFormat("ES2_19_5", "EI_IMPORTO19"));

            result.Add(InitCSVFormat("ES2_20_1", "EI_TIPO20"));
            result.Add(InitCSVFormat("ES2_20_2", "EI_ELE_IDE20"));
            result.Add(InitCSVFormat("ES2_20_3", "EI_TRI20"));
            result.Add(InitCSVFormat("ES2_20_4", "EI_ANNO20"));
            result.Add(InitCSVFormat("ES2_20_5", "EI_IMPORTO20"));

            result.Add(InitCSVFormat("ES2_21_1", "EI_TIPO21"));
            result.Add(InitCSVFormat("ES2_21_2", "EI_ELE_IDE21"));
            result.Add(InitCSVFormat("ES2_21_3", "EI_TRI21"));
            result.Add(InitCSVFormat("ES2_21_4", "EI_ANNO21"));
            result.Add(InitCSVFormat("ES2_21_5", "EI_IMPORTO21"));

            result.Add(InitCSVFormat("ES2_22_1", "EI_TIPO22"));
            result.Add(InitCSVFormat("ES2_22_2", "EI_ELE_IDE22"));
            result.Add(InitCSVFormat("ES2_22_3", "EI_TRI22"));
            result.Add(InitCSVFormat("ES2_22_4", "EI_ANNO22"));
            result.Add(InitCSVFormat("ES2_22_5", "EI_IMPORTO22"));

            result.Add(InitCSVFormat("ES2_23_1", "EI_TIPO23"));
            result.Add(InitCSVFormat("ES2_23_2", "EI_ELE_IDE23"));
            result.Add(InitCSVFormat("ES2_23_3", "EI_TRI23"));
            result.Add(InitCSVFormat("ES2_23_4", "EI_ANNO23"));
            result.Add(InitCSVFormat("ES2_23_5", "EI_IMPORTO23"));

            result.Add(InitCSVFormat("ES2_24_1", "EI_TIPO24"));
            result.Add(InitCSVFormat("ES2_24_2", "EI_ELE_IDE24"));
            result.Add(InitCSVFormat("ES2_24_3", "EI_TRI24"));
            result.Add(InitCSVFormat("ES2_24_4", "EI_ANNO24"));
            result.Add(InitCSVFormat("ES2_24_5", "EI_IMPORTO24"));

            result.Add(InitCSVFormat("ES2_25_1", "EI_TIPO25"));
            result.Add(InitCSVFormat("ES2_25_2", "EI_ELE_IDE25"));
            result.Add(InitCSVFormat("ES2_25_3", "EI_TRI25"));
            result.Add(InitCSVFormat("ES2_25_4", "EI_ANNO25"));
            result.Add(InitCSVFormat("ES2_25_5", "EI_IMPORTO25"));

            result.Add(InitCSVFormat("ES2_26_1", "EI_TIPO26"));
            result.Add(InitCSVFormat("ES2_26_2", "EI_ELE_IDE26"));
            result.Add(InitCSVFormat("ES2_26_3", "EI_TRI26"));
            result.Add(InitCSVFormat("ES2_26_4", "EI_ANNO26"));
            result.Add(InitCSVFormat("ES2_26_5", "EI_IMPORTO26"));

            result.Add(InitCSVFormat("ES2_27_1", "EI_TIPO27"));
            result.Add(InitCSVFormat("ES2_27_2", "EI_ELE_IDE27"));
            result.Add(InitCSVFormat("ES2_27_3", "EI_TRI27"));
            result.Add(InitCSVFormat("ES2_27_4", "EI_ANNO27"));
            result.Add(InitCSVFormat("ES2_27_5", "EI_IMPORTO27"));

            result.Add(InitCSVFormat("ES2_28_1", "EI_TIPO28"));
            result.Add(InitCSVFormat("ES2_28_2", "EI_ELE_IDE28"));
            result.Add(InitCSVFormat("ES2_28_3", "EI_TRI28"));
            result.Add(InitCSVFormat("ES2_28_4", "EI_ANNO28"));
            result.Add(InitCSVFormat("ES2_28_5", "EI_IMPORTO28"));





            result.Add(InitCSVFormat("SS2_1_1", "SE_SEZ1"));
            result.Add(InitCSVFormat("SS2_1_2", "SE_TRI1"));
            result.Add(InitCSVFormat("SS2_1_3", "SE_ENTE1"));
            result.Add(InitCSVFormat("SS2_1_4", "SE_F11"));
            result.Add(InitCSVFormat("SS2_1_5", "SE_F21"));
            result.Add(InitCSVFormat("SS2_1_6", "SE_F31"));
            result.Add(InitCSVFormat("SS2_1_7", "SE_F41"));
            result.Add(InitCSVFormat("SS2_1_8", "SE_NFAB1"));
            result.Add(InitCSVFormat("SS2_1_9", "SE_RATE1"));
            result.Add(InitCSVFormat("SS2_1_10", "SE_ANNO1"));
            result.Add(InitCSVFormat("SS2_1_11", "SE_DETR1"));
            result.Add(InitCSVFormat("SS2_1_12", "SE_IMPV1"));
            result.Add(InitCSVFormat("SS2_1_13", "SE_IMPC1"));

            result.Add(InitCSVFormat("SS2_2_1", "SE_SEZ2"));
            result.Add(InitCSVFormat("SS2_2_2", "SE_TRI2"));
            result.Add(InitCSVFormat("SS2_2_3", "SE_ENTE2"));
            result.Add(InitCSVFormat("SS2_2_4", "SE_F12"));
            result.Add(InitCSVFormat("SS2_2_5", "SE_F22"));
            result.Add(InitCSVFormat("SS2_2_6", "SE_F32"));
            result.Add(InitCSVFormat("SS2_2_7", "SE_F42"));
            result.Add(InitCSVFormat("SS2_2_8", "SE_NFAB2"));
            result.Add(InitCSVFormat("SS2_2_9", "SE_RATE2"));
            result.Add(InitCSVFormat("SS2_2_10", "SE_ANNO2"));
            result.Add(InitCSVFormat("SS2_2_11", "SE_DETR2"));
            result.Add(InitCSVFormat("SS2_2_12", "SE_IMPV2"));
            result.Add(InitCSVFormat("SS2_2_13", "SE_IMPC2"));

            result.Add(InitCSVFormat("SS2_3_1", "SE_SEZ3"));
            result.Add(InitCSVFormat("SS2_3_2", "SE_TRI3"));
            result.Add(InitCSVFormat("SS2_3_3", "SE_ENTE3"));
            result.Add(InitCSVFormat("SS2_3_4", "SE_F13"));
            result.Add(InitCSVFormat("SS2_3_5", "SE_F23"));
            result.Add(InitCSVFormat("SS2_3_6", "SE_F33"));
            result.Add(InitCSVFormat("SS2_3_7", "SE_F43"));
            result.Add(InitCSVFormat("SS2_3_8", "SE_NFAB3"));
            result.Add(InitCSVFormat("SS2_3_9", "SE_RATE3"));
            result.Add(InitCSVFormat("SS2_3_10", "SE_ANNO3"));
            result.Add(InitCSVFormat("SS2_3_11", "SE_DETR3"));
            result.Add(InitCSVFormat("SS2_3_12", "SE_IMPV3"));
            result.Add(InitCSVFormat("SS2_3_13", "SE_IMPC3"));

            result.Add(InitCSVFormat("SS2_4_1", "SE_SEZ4"));
            result.Add(InitCSVFormat("SS2_4_2", "SE_TRI4"));
            result.Add(InitCSVFormat("SS2_4_3", "SE_ENTE4"));
            result.Add(InitCSVFormat("SS2_4_4", "SE_F14"));
            result.Add(InitCSVFormat("SS2_4_5", "SE_F24"));
            result.Add(InitCSVFormat("SS2_4_6", "SE_F34"));
            result.Add(InitCSVFormat("SS2_4_7", "SE_F44"));
            result.Add(InitCSVFormat("SS2_4_8", "SE_NFAB4"));
            result.Add(InitCSVFormat("SS2_4_9", "SE_RATE4"));
            result.Add(InitCSVFormat("SS2_4_10", "SE_ANNO4"));
            result.Add(InitCSVFormat("SS2_4_11", "SE_DETR4"));
            result.Add(InitCSVFormat("SS2_4_12", "SE_IMPV4"));
            result.Add(InitCSVFormat("SS2_4_13", "SE_IMPC4"));

            result.Add(InitCSVFormat("SS2_5_1", "SE_SEZ5"));
            result.Add(InitCSVFormat("SS2_5_2", "SE_TRI5"));
            result.Add(InitCSVFormat("SS2_5_3", "SE_ENTE5"));
            result.Add(InitCSVFormat("SS2_5_4", "SE_F15"));
            result.Add(InitCSVFormat("SS2_5_5", "SE_F25"));
            result.Add(InitCSVFormat("SS2_5_6", "SE_F35"));
            result.Add(InitCSVFormat("SS2_5_7", "SE_F45"));
            result.Add(InitCSVFormat("SS2_5_8", "SE_NFAB5"));
            result.Add(InitCSVFormat("SS2_5_9", "SE_RATE5"));
            result.Add(InitCSVFormat("SS2_5_10", "SE_ANNO5"));
            result.Add(InitCSVFormat("SS2_5_11", "SE_DETR5"));
            result.Add(InitCSVFormat("SS2_5_12", "SE_IMPV5"));
            result.Add(InitCSVFormat("SS2_5_13", "SE_IMPC5"));

            result.Add(InitCSVFormat("SS2_6_1", "SE_SEZ6"));
            result.Add(InitCSVFormat("SS2_6_2", "SE_TRI6"));
            result.Add(InitCSVFormat("SS2_6_3", "SE_ENTE6"));
            result.Add(InitCSVFormat("SS2_6_4", "SE_F16"));
            result.Add(InitCSVFormat("SS2_6_5", "SE_F26"));
            result.Add(InitCSVFormat("SS2_6_6", "SE_F36"));
            result.Add(InitCSVFormat("SS2_6_7", "SE_F46"));
            result.Add(InitCSVFormat("SS2_6_8", "SE_NFAB6"));
            result.Add(InitCSVFormat("SS2_6_9", "SE_RATE6"));
            result.Add(InitCSVFormat("SS2_6_10", "SE_ANNO6"));
            result.Add(InitCSVFormat("SS2_6_11", "SE_DETR6"));
            result.Add(InitCSVFormat("SS2_6_12", "SE_IMPV6"));
            result.Add(InitCSVFormat("SS2_6_13", "SE_IMPC6"));

            result.Add(InitCSVFormat("SS2_7_1", "SE_SEZ7"));
            result.Add(InitCSVFormat("SS2_7_2", "SE_TRI7"));
            result.Add(InitCSVFormat("SS2_7_3", "SE_ENTE7"));
            result.Add(InitCSVFormat("SS2_7_4", "SE_F17"));
            result.Add(InitCSVFormat("SS2_7_5", "SE_F27"));
            result.Add(InitCSVFormat("SS2_7_6", "SE_F37"));
            result.Add(InitCSVFormat("SS2_7_7", "SE_F47"));
            result.Add(InitCSVFormat("SS2_7_8", "SE_NFAB7"));
            result.Add(InitCSVFormat("SS2_7_9", "SE_RATE7"));
            result.Add(InitCSVFormat("SS2_7_10", "SE_ANNO7"));
            result.Add(InitCSVFormat("SS2_7_11", "SE_DETR7"));
            result.Add(InitCSVFormat("SS2_7_12", "SE_IMPV7"));
            result.Add(InitCSVFormat("SS2_7_13", "SE_IMPC7"));

            result.Add(InitCSVFormat("SS2_8_1", "SE_SEZ8"));
            result.Add(InitCSVFormat("SS2_8_2", "SE_TRI8"));
            result.Add(InitCSVFormat("SS2_8_3", "SE_ENTE8"));
            result.Add(InitCSVFormat("SS2_8_4", "SE_F18"));
            result.Add(InitCSVFormat("SS2_8_5", "SE_F28"));
            result.Add(InitCSVFormat("SS2_8_6", "SE_F38"));
            result.Add(InitCSVFormat("SS2_8_7", "SE_F48"));
            result.Add(InitCSVFormat("SS2_8_8", "SE_NFAB8"));
            result.Add(InitCSVFormat("SS2_8_9", "SE_RATE8"));
            result.Add(InitCSVFormat("SS2_8_10", "SE_ANNO8"));
            result.Add(InitCSVFormat("SS2_8_11", "SE_DETR8"));
            result.Add(InitCSVFormat("SS2_8_12", "SE_IMPV8"));
            result.Add(InitCSVFormat("SS2_8_13", "SE_IMPC8"));

            result.Add(InitCSVFormat("SS2_9_1", "SE_SEZ9"));
            result.Add(InitCSVFormat("SS2_9_2", "SE_TRI9"));
            result.Add(InitCSVFormat("SS2_9_3", "SE_ENTE9"));
            result.Add(InitCSVFormat("SS2_9_4", "SE_F19"));
            result.Add(InitCSVFormat("SS2_9_5", "SE_F29"));
            result.Add(InitCSVFormat("SS2_9_6", "SE_F39"));
            result.Add(InitCSVFormat("SS2_9_7", "SE_F49"));
            result.Add(InitCSVFormat("SS2_9_8", "SE_NFAB9"));
            result.Add(InitCSVFormat("SS2_9_9", "SE_RATE9"));
            result.Add(InitCSVFormat("SS2_9_10", "SE_ANNO9"));
            result.Add(InitCSVFormat("SS2_9_11", "SE_DETR9"));
            result.Add(InitCSVFormat("SS2_9_12", "SE_IMPV9"));
            result.Add(InitCSVFormat("SS2_9_13", "SE_IMPC9"));

            result.Add(InitCSVFormat("SS2_10_1", "SE_SEZ10"));
            result.Add(InitCSVFormat("SS2_10_2", "SE_TRI10"));
            result.Add(InitCSVFormat("SS2_10_3", "SE_ENTE10"));
            result.Add(InitCSVFormat("SS2_10_4", "SE_F110"));
            result.Add(InitCSVFormat("SS2_10_5", "SE_F210"));
            result.Add(InitCSVFormat("SS2_10_6", "SE_F310"));
            result.Add(InitCSVFormat("SS2_10_7", "SE_F410"));
            result.Add(InitCSVFormat("SS2_10_8", "SE_NFAB10"));
            result.Add(InitCSVFormat("SS2_10_9", "SE_RATE10"));
            result.Add(InitCSVFormat("SS2_10_10", "SE_ANNO10"));
            result.Add(InitCSVFormat("SS2_10_11", "SE_DETR10"));
            result.Add(InitCSVFormat("SS2_10_12", "SE_IMPV10"));
            result.Add(InitCSVFormat("SS2_10_13", "SE_IMPC10"));


            result.Add(InitCSVFormat("AS6_1_1", "AC_ENTE1"));
            result.Add(InitCSVFormat("AS6_1_2", "AC_PROV1"));
            result.Add(InitCSVFormat("AS6_1_3", "AC_TRIB1"));
            result.Add(InitCSVFormat("AS6_1_4", "AC_IDEN1"));
            result.Add(InitCSVFormat("AS6_1_5", "AC_RATE1"));
            result.Add(InitCSVFormat("AS6_1_6", "AC_RIFE1"));
            result.Add(InitCSVFormat("AS6_1_7", "AC_IMPV1"));

            result.Add(InitCSVFormat("AS6_2_1", "AC_ENTE2"));
            result.Add(InitCSVFormat("AS6_2_2", "AC_PROV2"));
            result.Add(InitCSVFormat("AS6_2_3", "AC_TRIB2"));
            result.Add(InitCSVFormat("AS6_2_4", "AC_IDEN2"));
            result.Add(InitCSVFormat("AS6_2_5", "AC_RATE2"));
            result.Add(InitCSVFormat("AS6_2_6", "AC_RIFE2"));
            result.Add(InitCSVFormat("AS6_2_7", "AC_IMPV2"));

            result.Add(InitCSVFormat("AS6_3_1", "AC_ENTE3"));
            result.Add(InitCSVFormat("AS6_3_2", "AC_PROV3"));
            result.Add(InitCSVFormat("AS6_3_3", "AC_TRIB3"));
            result.Add(InitCSVFormat("AS6_3_4", "AC_IDEN3"));
            result.Add(InitCSVFormat("AS6_3_5", "AC_RATE3"));
            result.Add(InitCSVFormat("AS6_3_6", "AC_RIFE3"));
            result.Add(InitCSVFormat("AS6_3_7", "AC_IMPV3"));

            result.Add(InitCSVFormat("AS6_4_1", "AC_ENTE4"));
            result.Add(InitCSVFormat("AS6_4_2", "AC_PROV4"));
            result.Add(InitCSVFormat("AS6_4_3", "AC_TRIB4"));
            result.Add(InitCSVFormat("AS6_4_4", "AC_IDEN4"));
            result.Add(InitCSVFormat("AS6_4_5", "AC_RATE4"));
            result.Add(InitCSVFormat("AS6_4_6", "AC_RIFE4"));
            result.Add(InitCSVFormat("AS6_4_7", "AC_IMPV4"));

            result.Add(InitCSVFormat("AS6_5_1", "AC_ENTE5"));
            result.Add(InitCSVFormat("AS6_5_2", "AC_PROV5"));
            result.Add(InitCSVFormat("AS6_5_3", "AC_TRIB5"));
            result.Add(InitCSVFormat("AS6_5_4", "AC_IDEN5"));
            result.Add(InitCSVFormat("AS6_5_5", "AC_RATE5"));
            result.Add(InitCSVFormat("AS6_5_6", "AC_RIFE5"));
            result.Add(InitCSVFormat("AS6_5_7", "AC_IMPV5"));

            result.Add(InitCSVFormat("AS6_6_1", "AC_ENTE6"));
            result.Add(InitCSVFormat("AS6_6_2", "AC_PROV6"));
            result.Add(InitCSVFormat("AS6_6_3", "AC_TRIB6"));
            result.Add(InitCSVFormat("AS6_6_4", "AC_IDEN6"));
            result.Add(InitCSVFormat("AS6_6_5", "AC_RATE6"));
            result.Add(InitCSVFormat("AS6_6_6", "AC_RIFE6"));
            result.Add(InitCSVFormat("AS6_6_7", "AC_IMPV6"));

            result.Add(InitCSVFormat("AS6_7_1", "AC_ENTE7"));
            result.Add(InitCSVFormat("AS6_7_2", "AC_PROV7"));
            result.Add(InitCSVFormat("AS6_7_3", "AC_TRIB7"));
            result.Add(InitCSVFormat("AS6_7_4", "AC_IDEN7"));
            result.Add(InitCSVFormat("AS6_7_5", "AC_RATE7"));
            result.Add(InitCSVFormat("AS6_7_6", "AC_RIFE7"));
            result.Add(InitCSVFormat("AS6_7_7", "AC_IMPV7"));

            result.Add(InitCSVFormat("AS6_8_1", "AC_CODUFF"));
            result.Add(InitCSVFormat("AS6_8_2", "AC_CODATTO"));
            result.Add(InitCSVFormat("AS6_8_3", "AC_TOTO"));
            result.Add(InitCSVFormat("", "AC_TOTP"));
            result.Add(InitCSVFormat("AS6_8_4", "AC_SALDO"));

            result.Add(InitCSVFormat("PS1_3_1", "PRE_IDENTI"));
            result.Add(InitCSVFormat("PS1_3_2", "PRE_IMPORTO"));

            result.Add(InitCSVFormat("S7_4_1", "TOTGEN"));
            result.Add(InitCSVFormat("", "Quality"));
        }


        private ResultDataFormat InitCSVFormat(string strNameInCode, string strNameFromCustom)
        {
            ResultDataFormat tempCSVResult = new ResultDataFormat();
            tempCSVResult.strNameInCode = strNameInCode;
            tempCSVResult.strNameFromCustom = strNameFromCustom;
            return tempCSVResult;
        }

        public static CSVResult GetInstance()
        {
            if (instance == null)
            {
                instance = new CSVResult();
            }
            return instance;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFormType"></param>
        /// <returns></returns>
        public List<ResultDataFormat> GetResultPerTypeSort(string strFormType)
        {
            List<ResultDataFormat> tempResultPerType = new List<ResultDataFormat>();
            ResultDataFormat tempSwap = null;
            if (strFormType.Equals("N"))
            {
                foreach (ResultDataFormat rdf in result)
                {
                    if ((rdf.strNameInCode.Length > 2
                        && rdf.strNameInCode[0] == 'S' && Char.IsNumber(rdf.strNameInCode[1]))
                        || rdf.strNameInCode == "" || rdf.strNameInCode == "TaxCodeQuality" || rdf.strNameInCode == "ClassifyFlag")
                    {
                        tempResultPerType.Add(rdf);
                    }
                }
                int nSortCount = 0;
                //如果说前几位不参加排序的话
                //排序的开始位置和结束位置考虑一下
                for (int i = 0; i < tempResultPerType.Count; i++)
                {
                    if (tempResultPerType[i].strOCRResult.Length == 0)
                    {
                        tempSwap = tempResultPerType[i];
                        for (int j = i; j < tempResultPerType.Count - 1; j++)
                        {
                            tempResultPerType[j] = tempResultPerType[j + 1];
                        }
                        tempResultPerType[tempResultPerType.Count - 1] = tempSwap;
                        i--;
                        nSortCount++;
                        if (nSortCount > tempResultPerType.Count)
                        {
                            break;
                        }
                    }
                }
            }

            return tempResultPerType;
        }

        public void ClearContent()
        {
            foreach (var item in result)
            {
                item.strOCRResult = "";
            }
        }
    }

    /// <summary>
    /// 将CSVResult中的数据存到文件中去
    /// </summary>
    class CSVEngine
    {
        private static CSVResult _result;

        public CSVEngine(string strImageName, string strFormType, CSVResult result)
        {
            _result = result;

            foreach (var temp in result.result)
            {
                if (temp.strNameFromCustom.Equals("DocFileName"))
                {
                    temp.strOCRResult = strImageName;
                }
                if (temp.strNameFromCustom.Equals("DocumentType"))
                {
                    temp.strOCRResult = strFormType;
                }
            }
        }

        public CSVEngine(CSVResult result)
        {
            _result = result;

        }

        public void Save(string strCSVPath)
        {
            if (String.IsNullOrEmpty(strCSVPath) || _result == null)
            {
                return;
            }
            //added by Chenyang Wang for make the .csv file splitted by semicolon
            //CsvConfiguration config = new CsvConfiguration();
            //config.Delimiter = ';';
            //using(var writer = new CsvWriter(new StreamWriter(strCSVPath),config))
            //added end
            using (var writer = new CsvWriter(new StreamWriter(strCSVPath)))
            {
                foreach (var temp in _result.result)
                {
                    writer.WriteField(temp.strNameFromCustom);
                }
                writer.NextRecord();

                // for inner debug
                foreach (var temp in _result.result)
                {
                    writer.WriteField(temp.strNameInCode);
                }
                writer.NextRecord();

                foreach (var temp in _result.result)
                {
                    if (temp.strOCRResult != null)
                    {
                        if (temp.strOCRResult.Equals(""))
                        {
                            writer.WriteField("");
                        }
                        else
                        {
                            writer.WriteField(temp.strOCRResult);
                        }

                    }
                    else
                    {
                        writer.WriteField(temp.strOCRResult);
                    }

                }
                writer.NextRecord();

            }
        }

        public static CSVResult Load(string strCSVPath)
        {
            CSVResult result = CSVResult.GetInstance();
            _result = result;
            if (!File.Exists(strCSVPath))
            {
                using(System.IO.File.Create(strCSVPath))
                {
                    Console.WriteLine("Create File.");
                }
                using (var writer = new CsvWriter(new StreamWriter(strCSVPath)))
                {
                    foreach (var temp in _result.result)
                    {
                        writer.WriteField(temp.strNameFromCustom);
                    }
                    writer.NextRecord();
                    // for inner debug
                    foreach (var temp in _result.result)
                    {
                        writer.WriteField(temp.strNameInCode);
                    }
                    writer.NextRecord();
                    foreach (var temp in _result.result)
                    {
                        if (temp.strOCRResult != null)
                        {
                            if (temp.strOCRResult.Equals(""))
                            {
                                writer.WriteField("");
                            }
                            else
                            {
                                writer.WriteField(temp.strOCRResult);
                            }
                        }
                        else
                        {
                            writer.WriteField(temp.strOCRResult);
                        }
                    }
                    writer.NextRecord();
                }
                return result;
            }
            using (var reader = new CsvReader(new StreamReader(strCSVPath)))
            {
                System.IO.FileInfo file = new System.IO.FileInfo(strCSVPath);
                if (file.Length == 0)//判断一下大小，要是为零就不读了
                {
                    return result;
                }
                while (reader.Read())
                {
                    foreach (var temp in result.result)
                    {
                        try
                        {
                            temp.strOCRResult = reader.GetField(temp.strNameFromCustom);
                        }
                        catch (System.Exception ex)
                        {
                            temp.strOCRResult = "";
                        }

                    }
                }
            }
            return result;
        }

        public int getCharactorTotalNum()
        {
            int nCount = 0;
            if (_result == null)
            {
                return 0;
            }
            foreach (ResultDataFormat rdf in _result.result)
            {
                if (rdf.strNameFromCustom.Equals("DocFileName") || rdf.strNameFromCustom.Equals("DocumentType") || rdf.strNameFromCustom.Equals("ClassifyFlag")
                    || rdf.strNameFromCustom.Equals("TaxCodeQuality"))
                {
                    continue;
                }
                if (string.IsNullOrEmpty(rdf.strOCRResult))
                {
                    nCount += 0;
                }
                else
                {
                    nCount += rdf.strOCRResult.Length;
                }
            }

            LogInfo.CharacterTotalCount += nCount;//累加打开工具处理的总字符数

            return nCount;
        }


    }
}
