using System;
using System.Collections.Generic;
using System.Text;

namespace Training.Common
{
	public static class TrainingUtils
	{
        #region CRC16_CITT_TABLE
        static ushort[] _CRC16_CITT_TABLE;
        static ushort[] CRC16_CITT_TABLE
        {
            get
            {
                if(_CRC16_CITT_TABLE == null)
                {
                    const ushort poly = 4129;
                    ushort temp, a;

                    _CRC16_CITT_TABLE = new ushort[256];

                    for (int i = 0; i < _CRC16_CITT_TABLE.Length; ++i)
                    {
                        temp = 0;
                        a = (ushort)(i << 8);
                        for (int j = 0; j < 8; ++j)
                        {
                            if (((temp ^ a) & 0x8000) != 0)
                                temp = (ushort)((temp << 1) ^ poly);
                            else
                                temp <<= 1;
                            a <<= 1;
                        }

                        _CRC16_CITT_TABLE[i] = temp;
                    }
                }

                return _CRC16_CITT_TABLE;
            }
        }
		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <param name="bytes"></param>
		/// <returns></returns>
		public static ushort CRC16_CCITT(byte[] bytes)
        {
            ushort crc = 0xffff;

            for (int i = 0; i < bytes.Length; ++i)
            {
                crc = (ushort)((crc << 8) ^ CRC16_CITT_TABLE[((crc >> 8) ^ (0xff & bytes[i]))]);
            }

            return crc;
        }
    }
}
