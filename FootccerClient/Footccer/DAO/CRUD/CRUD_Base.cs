using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootccerClient.Footccer.DAO.CRUD
{
    /// <summary>
    /// MySqlCommand를 사용한 CRUD 인터페이스를 제공합니다. <br/>
    /// MySqlCommand 자원을 사용하므로 필요시에만 생성해서 사용해주세요.
    /// </summary>
    public abstract class CRUD_Base
    {
        protected static string DefaultMsg_NoResult = "검색 결과가 없습니다..";
        protected static string DefaultMsg_DuplicateResults = "DB 검색 결과가 중복 발견되었습니다..";

        protected MySqlCommand cmd { get; }

        public CRUD_Base(MySqlCommand cmd) 
        { 
            this.cmd = cmd;
        }


        /// <summary>
        /// MySqlDataReader를 받아 ParseMethod의 결과값을 하나만 반환합니다. <br/>
        /// 결과값이 단 하나가 아닐 경우 예외를 던집니다. <br/>
        /// <br> 내부에서 MySqlDataReader.Read()를 실행하므로 중복작성하지 말아주세요. </br>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        protected T ReadData<T>(Func<MySqlDataReader, T> ParseMethod)
        {
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                return GetOnlyOne(rdr, ParseMethod);
            }
        }


        /// <summary>
        /// MySqlDataReader를 받아 결과값 목록을 반환합니다. <br/>
        /// <br> 내부에서 MySqlDataReader.Read()를 실행하므로 중복작성하지 말아주세요. </br>
        /// </summary>
        /// <returns></returns>
        protected List<T> ReadDataList<T>(Func<MySqlDataReader, T> ParseMethod)
        {
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                return GetList_AfterParsing(rdr, ParseMethod);
            }
        }


        /// <summary>
        /// 생성된 MySqlDataReader에 대해 가능한 모든 Read마다 ParseMethod를 실행하여 _list에 추가하여 반환합니다.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected List<T> GetList_AfterParsing<T>(MySqlDataReader rdr, Func<MySqlDataReader, T> ParseMethod)
        {
            List<T> _list = new List<T>();

            while (rdr.Read())
            {
                T userInfo = ParseMethod(rdr);
                _list.Add(userInfo);
            }

            return _list;
        }


        /// <summary>
        /// 리스트를 입력받아 단 하나만 있을 때 반환합니다. <br/>
        /// 그 외에는 예외를 던집니다. <br/>
        /// </summary>
        /// <exception cref="Exception"></exception>
        protected T GetOnlyOne<T>(MySqlDataReader rdr, Func<MySqlDataReader, T> ParseMethod) => GetOnlyOne(GetList_AfterParsing(rdr, ParseMethod));
        /// <summary>
        /// 리스트를 입력받아 단 하나만 있을 때 반환합니다. <br/>
        /// 그 외에는 예외를 던집니다. <br/>
        /// </summary>
        /// <exception cref="Exception"></exception>
        protected T GetOnlyOne<T>(List<T> _list) => GetOnlyOne(_list, DefaultMsg_NoResult, DefaultMsg_DuplicateResults); 
        /// <summary>
        /// 리스트를 입력받아 단 하나만 있을 때 반환합니다. <br/>
        /// 그 외에는 예외를 던집니다. <br/>
        /// </summary>
        /// <exception cref="Exception"></exception>
        protected T GetOnlyOne<T>(List<T> _list, string noResultMsg , string duplicateResultsMsg)
        {
            int _count = _list.Count;
            if (_count < 1) { throw new Exception(noResultMsg); }
            else if (_count > 1) { throw new Exception(duplicateResultsMsg); }
            else { return _list[0]; }
        }
    }
}
