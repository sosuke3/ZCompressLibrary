using System;
using System.Collections.Generic;
using System.Text;

namespace ZCompressLibrary
{
    public static class Compress
    {
        public static byte[] ALTTPCompressGraphics(byte[] u_data, int start, int length)
        {
            return std_nintendo_compress(u_data, start, length, Common.D_NINTENDO_C_MODE2);
        }

        public static byte[] ALTTPCompressOverworld(byte[] u_data, int start, int length)
        {
            return std_nintendo_compress(u_data, start, length, Common.D_NINTENDO_C_MODE1);
        }

        static byte[] std_nintendo_compress(byte[] u_data, int start, int length, byte mode)
        {
            throw new NotImplementedException();
//            // we will realloc later
//            List<byte> compressed_data = new List<byte>(); //(char*)malloc(lenght + 3); // Worse cas is a copy of the string with extended header (probably should abord if more)
//            compression_piece* compressed_chain = new_compression_piece(1, 1, "aaa", 2);
//            compression_piece* compressed_chain_start = compressed_chain;

//            unsigned int u_data_pos = start;
//            unsigned int last_pos = start + lenght - 1;
//            s_debug("max pos :%d\n", last_pos);
//            //unsigned int previous_start = start;
//            unsigned int data_size_taken[5] = { 0, 0, 0, 0, 0 };
//            unsigned int cmd_size[5] = { 0, 1, 2, 1, 2 };
//            char cmd_args[5][2] = {{0, 0}, {0, 0}, {0, 0}, {0, 0}, {0, 0}};
//    unsigned int bytes_since_last_compression = 0; // Used when skipping using copy

//    while (1) {
//        memset(data_size_taken, 0, sizeof(data_size_taken));
//        memset(cmd_args, 0, sizeof(cmd_args));
//        s_debug("Testing every command\n");

//        /* We test every command to see the gain with current position */
//        {   //BYTE REPEAT
//            s_debug("Testing byte repeat\n");
//        unsigned int pos = u_data_pos;
//        char byte_to_repeat = u_data[pos];
//            while (pos <= last_pos && u_data[pos] == byte_to_repeat)
//            {
//                data_size_taken[D_CMD_BYTE_REPEAT]++;
//                pos++;
//            }
//    cmd_args[D_CMD_BYTE_REPEAT][0] = byte_to_repeat;
//        }
//        {   // WORD REPEAT
//            s_debug("Testing word repeat\n");
//            if (u_data_pos + 2 <= last_pos && u_data[u_data_pos] != u_data[u_data_pos + 1])
//            {
//                unsigned int pos = u_data_pos;
//char byte1 = u_data[pos];
//char byte2 = u_data[pos + 1];
//pos += 2;
//                data_size_taken[D_CMD_WORD_REPEAT] = 2;
//                while (pos + 1 <= last_pos) {
//                    if (u_data[pos] == byte1 && u_data[pos + 1] == byte2)
//                        data_size_taken[D_CMD_WORD_REPEAT] += 2;
//                    else
//                        break;
//                    pos += 2;
//                }
//                cmd_args[D_CMD_WORD_REPEAT][0] = byte1;
//                cmd_args[D_CMD_WORD_REPEAT][1] = byte2;
//            }
//        }
//        {   // INC BYTE
//            s_debug("Testing byte inc\n");
//unsigned int pos = u_data_pos;
//char byte = u_data[pos];
//            pos++;
//            data_size_taken[D_CMD_BYTE_INC] = 1;
//            while (pos <= last_pos && ++byte == u_data[pos])
//            {
//                data_size_taken[D_CMD_BYTE_INC]++;
//                pos++;
//            }
//            cmd_args[D_CMD_BYTE_INC][0] = u_data[u_data_pos];
//        }
//        {   // INTRA CPY
//            s_debug("Testing intra copy\n");
//            if (u_data_pos != start)
//            {
//                unsigned int searching_pos = start;
////unsigned int compressed_lenght = u_data_pos - start;
//unsigned int current_pos_u = u_data_pos;
//unsigned int copied_size = 0;
//unsigned int search_start = start;
//                /* printf("Searching for : ");
//                 for (unsigned int i = 0; i < 8; i++)
//                 {
//                     printf("%02X ", (unsigned char) u_data[u_data_pos + i]);
//                 }
//                 printf("\n");*/
//                while (searching_pos<u_data_pos && current_pos_u <= last_pos)
//                {
//                    while (u_data[current_pos_u] != u_data[searching_pos] && searching_pos<u_data_pos)
//                        searching_pos++;
//                    search_start = searching_pos;
//                    while (current_pos_u <= last_pos && u_data[current_pos_u] == u_data[searching_pos] && searching_pos<u_data_pos)
//                    {
//                        copied_size++;
//                        current_pos_u++;
//                        searching_pos++;
//                    }
//                    if (copied_size > data_size_taken[D_CMD_COPY_EXISTING])
//                    {
//                        search_start -= start;
//                        s_debug("-Found repeat of %d at %d\n", copied_size, search_start);
//data_size_taken[D_CMD_COPY_EXISTING] = copied_size;
//                        cmd_args[D_CMD_COPY_EXISTING][0] = search_start & 0xFF;
//                        cmd_args[D_CMD_COPY_EXISTING][1] = search_start >> 8;
//                    }
//                    current_pos_u = u_data_pos;
//                    copied_size = 0;
//                }

//            }
//        }
//        s_debug("Finding the best gain\n");
//// We check if a command managed to pick up 2 or more bytes
//// We don't want to be even with copy, since it's possible to merge copy
//unsigned int max_win = 2;
//unsigned int cmd_with_max = D_CMD_COPY;
//        for (unsigned int cmd_i = 1; cmd_i< 5; cmd_i++)
//        {
//            unsigned int cmd_size_taken = data_size_taken[cmd_i];
//            if (cmd_size_taken > max_win && cmd_size_taken > cmd_size[cmd_i] &&
//                    !(cmd_i == D_CMD_COPY_EXISTING && cmd_size_taken == 3) // FIXME: Should probably be a
//                    // table that say what is even with copy
//                    // but all other cmd are 2
//               )
//            {
//                s_debug("--C:%d / S:%d\n", cmd_i, cmd_size_taken);
//cmd_with_max = cmd_i;
//                max_win = cmd_size_taken;
//            }
//        }
//        if (cmd_with_max == D_CMD_COPY) // This is the worse case
//        {
//            s_debug("- Best command is copy\n");
//// We just move through the next byte and don't 'compress' yet, maybe something is better after.
//u_data_pos++;
//            bytes_since_last_compression++;
//            if (bytes_since_last_compression == 32 || u_data_pos > last_pos) // Arbitraty choice to do a 32 bytes grouping
//            {
//                char buffer[32];
//memcpy(buffer, u_data + u_data_pos - bytes_since_last_compression, bytes_since_last_compression);
//compression_piece* new_comp_piece = new_compression_piece(D_CMD_COPY, bytes_since_last_compression, buffer, bytes_since_last_compression);
//compressed_chain->next = new_comp_piece;
//                compressed_chain = new_comp_piece;
//                bytes_since_last_compression = 0;
//            }
//        }
//        else { // Yay we get something better
//            s_debug("- Ok we get a gain from %d\n", cmd_with_max);
//char buffer[2];
//buffer[0] = cmd_args[cmd_with_max][0];
//            if (cmd_size[cmd_with_max] == 2)
//                buffer[1] = cmd_args[cmd_with_max][1];
//            compression_piece* new_comp_piece = new_compression_piece(cmd_with_max, max_win, buffer, cmd_size[cmd_with_max]);
//            if (bytes_since_last_compression != 0) // If we let non compressed stuff, we need to add a copy chuck before
//            {
//                char* copy_buff = (char*)malloc(bytes_since_last_compression);
//memcpy(copy_buff, u_data + u_data_pos - bytes_since_last_compression, bytes_since_last_compression);
//compression_piece* copy_chuck = new_compression_piece(D_CMD_COPY, bytes_since_last_compression, copy_buff, bytes_since_last_compression);
//compressed_chain->next = copy_chuck;
//                compressed_chain = copy_chuck;
//            }
//            compressed_chain->next = new_comp_piece;
//            compressed_chain = new_comp_piece;
//            u_data_pos += max_win;
//            bytes_since_last_compression = 0;
//        }
//        if (u_data_pos > last_pos)
//            break;
//        if (std_nintendo_compression_sanity_check && compressed_chain_start->next != NULL)
//        {
//            // We don't call merge copy so we need more space
//            char* tmp = (char*)malloc(lenght * 2);
//            * compressed_size = create_compression_string(compressed_chain_start->next, tmp, mode);
//unsigned int p;
//unsigned int k;
//char* uncomp = std_nintendo_decompress(tmp, 0, 0, &p, &k, mode);
//# ifdef MY_DEBUG
//debug_str = speHexString(uncomp, p);

//printf("Compressed data so far : %s\n", debug_str);
//free(debug_str);
//#endif
//free(tmp);
//            if (memcmp(uncomp, u_data + start, p) != 0)
//            {
//                printf("Compressed data does not match uncompressed data at %d\n", (unsigned int) (u_data_pos - start));
//                free(uncomp);
//free_compression_chain(compressed_chain_start);
//                return NULL;
//            }
//            free(uncomp);

//        }
//    }
//    // First is a dumb place holder
//    merge_copy(compressed_chain_start->next);
//# ifdef MY_DEBUG
//compressed_chain = compressed_chain_start->next;
//    while (compressed_chain != NULL)
//    {
//        s_debug("--Piece--\n");
//print_compression_piece(compressed_chain);
//compressed_chain = compressed_chain->next;
//    }
//#endif
//    * compressed_size = create_compression_string(compressed_chain_start->next, compressed_data, mode);
//free_compression_chain(compressed_chain_start);
//    return compressed_data;
        }
    }
}
