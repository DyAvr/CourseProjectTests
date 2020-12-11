using Microsoft.VisualStudio.TestTools.UnitTesting;
using CourseProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CourseProject.Models.Exceptions;
using CourseProjectTests.Models;
using Microsoft.AspNetCore.Http;

namespace CourseProject.Models.Tests
{
    [TestClass()]
    public class EncryptionTests
    {
        [TestMethod()]
        public void ParseTextFromFileTestDocx()
        {
            string s = "Мы тут тестики пишем We are writing tests here 123!";
            using (var stream = File.OpenRead(@"..\..\..\Files\correct.DOCX"))
            {
                Assert.AreEqual(s, Encryption.ParseTextFromFile(new FileTest(stream, "\\correct.DOCX")));
            }
        }

        [TestMethod()]
        public void ParseTextFromFileTestTxt()
        {
            string s = "РњС‹ С‚СѓС‚ С‚РµСЃС‚РёРєРё РїРёС€РµРј We are writing tests here 123!";
            using (var stream = File.OpenRead(@"..\..\..\Files\correct.txt"))
            {
                Assert.AreEqual(s, Encryption.ParseTextFromFile(new FileTest(stream, "\\correct.txt")));
            }
        }

        [TestMethod()]
        public void ParseTextFromFileTestXlx()
        {
            using (var stream = File.OpenRead(@"..\..\..\Files\exel.XLSX"))
            {
                Assert.ThrowsException<WrongFileException>((() =>
                {
                    Encryption.ParseTextFromFile(new FileTest(stream, "\\exel.XLSX"));
                }));
            }
        }

        [TestMethod()]
        public void EncoderTestRus()
        {
            string s = "Ед ждк ыщвксящ зсмхе We are writing tests here 123!";
            Assert.AreEqual(s,Encryption.Encoder("Мы тут тестики пишем We are writing tests here 123!", "Шифр", "Rus"));
        }

        [TestMethod()]
        public void EncoderTestEng()
        {
            string s = "Мы тут тестики пишем Ym pyi ntqiprx vmhaw ygzt 123!";
            Assert.AreEqual(s, Encryption.Encoder("Мы тут тестики пишем We are writing tests here 123!", "Cipher", "Eng"));
        }

        [TestMethod()]
        public void EncoderTestRusWrongKey()
        {
            Assert.ThrowsException<WrongKeyException>((() =>
            {
                Encryption.Encoder("Мы тут тестики пишем We are writing tests here 123!", "Cipher", "Rus");
            }));
        }

        [TestMethod()]
        public void EncoderTestEngWrongKey()
        {
            Assert.ThrowsException<WrongKeyException>((() =>
            {
                Encryption.Encoder("Мы тут тестики пишем We are writing tests here 123!", "Шифр", "Eng");
            }));
        }

        [TestMethod()]
        public void DecoderTestRus()
        {
            string s = "Мы тут тестики пишем We are writing tests here 123!";
            Assert.AreEqual(s, Encryption.Decoder("Ед ждк ыщвксящ зсмхе We are writing tests here 123!", "Шифр", "Rus"));
        }

        [TestMethod()]
        public void DecoderTestEng()
        {
            string s = "Мы тут тестики пишем We are writing tests here 123!";
            Assert.AreEqual(s, Encryption.Decoder("Мы тут тестики пишем Ym pyi ntqiprx vmhaw ygzt 123!", "Cipher", "Eng"));
        }

        [TestMethod()]
        public void DecoderTestRusWrongKey()
        {
            Assert.ThrowsException<WrongKeyException>((() =>
            {
                Encryption.Decoder("Мы тут тестики пишем Ym pyi ntqiprx vmhaw ygzt 123!", "Cipher", "Rus");
            }));
        }

        [TestMethod()]
        public void DecoderTestEngWrongKey()
        {
            Assert.ThrowsException<WrongKeyException>((() =>
            {
                Encryption.Decoder("Мы тут тестики пишем We are writing tests here 123!", "Шифр", "Eng");
            }));
        }

    }
}