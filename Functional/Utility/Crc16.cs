using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional.Implementation;

using Functional.Test;

namespace Functional.Utility {
    [Coverage(TestCoverage.Utility_crc16_func)]
    public class FCrc16 {
        private const ushort polynomial = 0xA001;
        private ushort[] table = new ushort[256];
        public ushort[] Table { get { return this.table; } }
        
        public ushort ComputeChecksum(byte[] bytes) {
            return F.reducebetter<int,ushort>(F.range(0, bytes.Length), (x, y) => {
                return (ushort)((y >> 8) ^ this.table[(byte)(y ^ bytes[x])]);
            },0);
        }
        public byte[] ComputeChecksumBytes(byte[] bytes) {
            return BitConverter.GetBytes(this.ComputeChecksum(bytes));
        }
        public FCrc16() {
            
            foreach (ushort i in F.range((ushort)0, (ushort)table.Length)) {
                ushort value = 0;
                ushort temp = i;
                value = F.reduce<ushort>(F.range((ushort)0, (ushort)8), (v, _) => { // which one is the acc and which is the index? We ignore the index
                    if (((v ^ temp) & 0x0001) != 0) v = (ushort)((v >> 1) ^ polynomial);
                    else v = (ushort)(v >> 1);
                    temp = (ushort)(temp>>1);
                    return v;
                }, value);
                table[i] = value;
            }
        }
            
    }
    [Coverage(TestCoverage.Utility_crc16)]
    public class Crc16 {
        public Crc16() {
            ushort value;
            ushort temp;
            for (ushort i = 0; i < table.Length; ++i) {
                value = 0;
                temp = i;
                for (byte j = 0; j < 8; ++j) {
                    if (((value ^ temp) & 0x0001) != 0) {
                        value = (ushort)((value >> 1) ^ polynomial);
                    } else {
                        value >>= 1;
                    }
                    temp >>= 1;
                }
                table[i] = value;
            }
        }
        private const ushort polynomial = 0xA001;
        private ushort[] table = new ushort[256];
        public ushort[] Table { get { return this.table; } }
        public ushort ComputeChecksum(byte[] bytes) {
            ushort crc = 0;
            for (int i = 0; i < bytes.Length; ++i) {
                byte index = (byte)(crc ^ bytes[i]);
                crc = (ushort)((crc >> 8) ^ this.table[index]);
            }
            return crc;
        }

        public byte[] ComputeChecksumBytes(byte[] bytes) {
            ushort crc = ComputeChecksum(bytes);
            return BitConverter.GetBytes(crc);
        }
    }
}
