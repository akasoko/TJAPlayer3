using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using FDK;

namespace DTXMania
{
	internal class CAct演奏Drumsスコア : CAct演奏スコア共通
	{
		// CActivity 実装（共通クラスからの差分のみ）

		public unsafe override int On進行描画()
        {
            if (!base.b活性化してない)
            {
                if (base.b初めての進行描画)
                {
                    base.b初めての進行描画 = false;
                }
                long num = FDK.CSound管理.rc演奏用タイマ.n現在時刻;
                //if (num < base.n進行用タイマ)
                //{
                //    base.n進行用タイマ = num;
                //}
                //while ((num - base.n進行用タイマ) >= 10)
                //{
                //    for (int j = 0; j < 4; j++)
                //    {
                //        this.n現在表示中のスコア[j] += this.nスコアの増分[j];

                //        if (this.n現在表示中のスコア[j] > (long) this.n現在の本当のスコア[j])
                //            this.n現在表示中のスコア[j] = (long) this.n現在の本当のスコア[j];
                //    }
                //    base.n進行用タイマ += 10;

                //}
                if( !this.ctTimer.b停止中 )
                {
                    this.ctTimer.t進行();
                    if( this.ctTimer.b終了値に達した )
                    {
                        this.ctTimer.t停止();
                    }

                    //base.t小文字表示( 20, 150, string.Format( "{0,7:######0}", this.nスコアの増分.Guitar ) );
                }

                for (int i = 0; i < 4; i++)
                {
                    if (!this.ct点数アニメタイマ[i].b停止中)
                    {
                        this.ct点数アニメタイマ[i].t進行();
                        if (this.ct点数アニメタイマ[i].b終了値に達した)
                        {
                            this.ct点数アニメタイマ[i].t停止();
                        }
                    }
                }

                for (int i = 0; i < 4; i++)
                {
                    if (!this.ctボーナス加算タイマ[i].b停止中)
                    {
                        this.ctボーナス加算タイマ[i].t進行();
                        if (this.ctボーナス加算タイマ[i].b終了値に達した)
                        {
                            CDTXMania.stage演奏ドラム画面.actScore.BonusAdd(i);
                            this.ctボーナス加算タイマ[i].t停止();
                        }
                    }
                }

                //CDTXMania.act文字コンソール.tPrint(0, 0, C文字コンソール.Eフォント種別.白, this.ctボーナス加算タイマ[0].n現在の値.ToString());

                base.t小文字表示(CDTXMania.Skin.Game_Score_X[0], CDTXMania.Skin.Game_Score_Y[0], string.Format( "{0,7:######0}", this.n現在表示中のスコア[ 0 ].Taiko ), 0 , 256, 0);
                if( CDTXMania.stage演奏ドラム画面.bDoublePlay ) base.t小文字表示(CDTXMania.Skin.Game_Score_X[1], CDTXMania.Skin.Game_Score_Y[ 1 ], string.Format( "{0,7:######0}", this.n現在表示中のスコア[ 1 ].Taiko ), 0 , 256, 1);

                for( int i = 0; i < 256; i++ )
                {
                    if( this.stScore[ i ].b使用中 )
                    {
                        if( !this.stScore[ i ].ctTimer.b停止中 )
                        {
                            this.stScore[ i ].ctTimer.t進行();
                            if( this.stScore[ i ].ctTimer.b終了値に達した )
                            {
                                this.n現在表示中のスコア[ this.stScore[ i ].nPlayer ].Taiko += (long)this.stScore[ i ].nAddScore;
                                if( this.stScore[ i ].b表示中 == true )
                                    this.n現在表示中のAddScore--;
                                this.stScore[ i ].ctTimer.t停止();
                                this.stScore[ i ].b使用中 = false;
                            }

                            int xAdd = 0;
                            int yAdd = 0;
                            int alpha = 0;

                            if (this.stScore[i].ctTimer.n現在の値 < 10)
                            {
                                xAdd = 25;
                                alpha = 150;
                            }
                            else if (this.stScore[i].ctTimer.n現在の値 < 20)
                            {
                                xAdd = 10;
                                alpha = 200;
                            }
                            else if (this.stScore[i].ctTimer.n現在の値 < 30)
                            {
                                xAdd = -5;
                                alpha = 250;
                            }
                            else if (this.stScore[i].ctTimer.n現在の値 < 110)
                            {
                                xAdd = 0;
                                alpha = 240;
                            }
                            else if (this.stScore[i].ctTimer.n現在の値 < 114)
                            {
                                xAdd = -1;
                                alpha = 240;

                            }
                            else if (this.stScore[i].ctTimer.n現在の値 < 118)
                            {
                                xAdd = -2;
                                alpha = 240;

                            }
                            else if (this.stScore[i].ctTimer.n現在の値 < 122)
                            {
                                xAdd = -3;
                                alpha = 240;
                            }
                            else if (this.stScore[i].ctTimer.n現在の値 < 126)
                            {
                                xAdd = -4;
                                alpha = 250;
                            }
                            else if (this.stScore[i].ctTimer.n現在の値 < 130)
                            {
                                xAdd = -5;
                                alpha = 250;
                            }
                            else if (this.stScore[i].ctTimer.n現在の値 < 134)
                            {
                                xAdd = -6;
                                alpha = 250;
                            }
                            else if (this.stScore[i].ctTimer.n現在の値 < 138)
                            {
                                xAdd = -7;
                                alpha = 250;
                            }
                            else if (this.stScore[i].ctTimer.n現在の値 < 142)
                            {
                                xAdd = -8;
                                alpha = 250;
                            }
                            else if (this.stScore[i].ctTimer.n現在の値 < 146)
                            {
                                xAdd = -9;
                                alpha = 256;

                            }
                            else if (this.stScore[i].ctTimer.n現在の値 < 150)
                            {
                                xAdd = -10;
                                alpha = 256;
                            }
                            else if (this.stScore[i].ctTimer.n現在の値 < 154)
                            {
                                xAdd = -9;
                                alpha = 256;
                            }
                            else if (this.stScore[i].ctTimer.n現在の値 < 158)
                            {
                                xAdd = -8;
                                alpha = 256;
                            }
                            else if (this.stScore[i].ctTimer.n現在の値 < 162)
                            {
                                xAdd = -7;
                                alpha = 256;
                            }
                            else if (this.stScore[i].ctTimer.n現在の値 < 166)
                            {
                                xAdd = -6;
                                alpha = 256;
                            }
                            else if (this.stScore[i].ctTimer.n現在の値 < 170)
                            {
                                xAdd = -5;
                                alpha = 256;
                            }
                            else if (this.stScore[i].ctTimer.n現在の値 < 174)
                            {
                                xAdd = -4;
                                alpha = 256;
                            }
                            else if (this.stScore[i].ctTimer.n現在の値 < 178)
                            {
                                xAdd = -3;
                                alpha = 256;
                            }
                            else if (this.stScore[i].ctTimer.n現在の値 < 182)
                            {
                                xAdd = -2;
                                alpha = 256;
                            }
                            else if (this.stScore[i].ctTimer.n現在の値 < 186)
                            {
                                xAdd = -1;
                                alpha = 256;
                            }
                            else

                            {
                                xAdd = 0;
                                alpha = 256;
                            }



                                if (this.stScore[i].ctTimer.n現在の値 > 300)
                                {
                                    yAdd = -1;
                                }
                                if (this.stScore[i].ctTimer.n現在の値 > 310)
                                {
                                    yAdd = -2;
                                }
                                if (this.stScore[i].ctTimer.n現在の値 > 313)
                                {
                                    yAdd = -3;
                                }
                                if (this.stScore[i].ctTimer.n現在の値 > 316)
                                {
                                    yAdd = -4;
                                }
                                if (this.stScore[i].ctTimer.n現在の値 > 318)
                                {
                                    yAdd = -5;
                                }
                                if (this.stScore[i].ctTimer.n現在の値 > 320)
                                {
                                    yAdd = -6;
                                }
                                if (this.stScore[i].ctTimer.n現在の値 > 325)
                                {
                                    yAdd = -7;
                                }
                                if (this.stScore[i].ctTimer.n現在の値 > 330)
                                {
                                    yAdd = -8;
                                }
                                if (this.stScore[i].ctTimer.n現在の値 > 340)
                                {
                                    yAdd = -8;
                                    alpha = 256;
                                }
                                if (this.stScore[i].ctTimer.n現在の値 > 350)
                                {
                                    yAdd = -6;
                                    alpha = 256;
                                }
                                if (this.stScore[i].ctTimer.n現在の値 > 352)
                                {
                                    yAdd = -5;
                                    alpha = 256;
                                }
                                if (this.stScore[i].ctTimer.n現在の値 > 354)
                                {
                                    yAdd = -4;
                                    alpha = 256;
                                }
                                if (this.stScore[i].ctTimer.n現在の値 > 356)
                                {
                                    yAdd = -3;
                                    alpha = 256;
                                }
                                if (this.stScore[i].ctTimer.n現在の値 > 358)
                                {
                                    yAdd = -2;
                                    alpha = 256;
                                }
                                if (this.stScore[i].ctTimer.n現在の値 > 359)
                                {
                                    yAdd = -1;
                                    alpha = 256;
                                }
                                if (this.stScore[i].ctTimer.n現在の値 > 360)
                                {
                                    yAdd = 0;
                                    alpha = 256;
                                }
                                if (this.stScore[i].ctTimer.n現在の値 > 362)
                                {
                                    yAdd = 0;
                                    alpha = 256;
                                }
                                if (this.stScore[i].ctTimer.n現在の値 > 364)
                                {
                                    yAdd = 0;
                                    alpha = 256;
                                }
                                if (this.stScore[i].ctTimer.n現在の値 > 366)
                                {
                                    yAdd = 0;
                                    alpha = 256;
                                }

                                if (this.stScore[i].ctTimer.n現在の値 > 368)
                                {
                                    yAdd = 0;
                                    alpha = 256;
                                }
                                if (this.stScore[i].ctTimer.n現在の値 > 370)
                                {
                                    yAdd = 1;
                                    alpha = 200;
                                }
                                if (this.stScore[i].ctTimer.n現在の値 > 371)
                                {
                                    yAdd = 2;
                                    alpha = 200;
                                }
                                if (this.stScore[i].ctTimer.n現在の値 > 372)
                                {
                                    yAdd = 3;
                                    alpha = 200;
                                }
                                if (this.stScore[i].ctTimer.n現在の値 > 373)
                                {
                                    yAdd = 4;
                                    alpha = 200;
                                }
                                if (this.stScore[i].ctTimer.n現在の値 > 374)
                                {
                                    yAdd = 5;
                                    alpha = 200;
                                }

                                if (this.stScore[i].ctTimer.n現在の値 > 375)
                                {
                                    yAdd = 6;
                                    alpha = 200;
                                }

                                if (this.stScore[i].ctTimer.n現在の値 > 376)
                                {
                                    yAdd = 7;
                                    alpha = 200;
                                }
                                if (this.stScore[i].ctTimer.n現在の値 > 377)
                                {
                                    yAdd = 8;
                                    alpha = 200;
                                }
                                if (this.stScore[i].ctTimer.n現在の値 > 378)
                                {
                                    yAdd = 9;
                                    alpha = 200;
                                }
                                if (this.stScore[i].ctTimer.n現在の値 > 379)
                                {
                                    yAdd = 10;
                                    alpha = 200;
                                }
                                if (this.stScore[i].ctTimer.n現在の値 > 380)
                                {
                                    yAdd = 11;
                                    alpha = 200;

                                    if (this.stScore[i].ctTimer.n現在の値 > 381)
                                    {
                                        yAdd = 12;
                                        alpha = 150;
                                        this.ct点数アニメタイマ[stScore[i].nPlayer] = new CCounter(0, 11, 12, CDTXMania.Timer);
                                    }
                                    if (this.stScore[i].ctTimer.n現在の値 > 383)
                                    {
                                        yAdd = 13;
                                        alpha = 0;
                                    }
                                    if (this.stScore[i].ctTimer.n現在の値 > 384)
                                    {
                                        yAdd = 14;
                                        alpha = 0;
                                    }
                                    if (this.stScore[i].ctTimer.n現在の値 > 385)
                                    {
                                        yAdd = 15;
                                        alpha = 0;
                                    }

                                    if (this.stScore[i].ctTimer.n現在の値 > 386)
                                    {
                                        yAdd = 16;
                                        alpha = 0;
                                    }
                                    if (this.stScore[i].ctTimer.n現在の値 > 387)
                                    {
                                        yAdd = 17;
                                        alpha = 0;
                                    }
                                    if (this.stScore[i].ctTimer.n現在の値 > 388)
                                    {
                                        yAdd = 18;
                                        alpha = 0;
                                    }
                                    if (this.stScore[i].ctTimer.n現在の値 > 389)
                                    {
                                        yAdd = 19;
                                        alpha = 0;
                                    }
                                    if (this.stScore[i].ctTimer.n現在の値 > 390)
                                    {
                                        yAdd = 20;
                                        alpha = 0;
                                    }
                                }
                            
                                if ( this.n現在表示中のAddScore < 10 && this.stScore[ i ].bBonusScore == false )
                                base.t小文字表示(CDTXMania.Skin.Game_Score_Add_X[this.stScore[i].nPlayer] + xAdd, this.stScore[ i ].nPlayer == 0 ? CDTXMania.Skin.Game_Score_Add_Y[ this.stScore[ i ].nPlayer ] + yAdd : CDTXMania.Skin.Game_Score_Add_Y[ this.stScore[ i ].nPlayer ] - yAdd, string.Format( "{0,7:######0}", this.stScore[ i ].nAddScore ), this.stScore[ i ].nPlayer + 1 , alpha, stScore[i].nPlayer);
                            if( this.n現在表示中のAddScore < 10 && this.stScore[ i ].bBonusScore == true )
                                base.t小文字表示(CDTXMania.Skin.Game_Score_AddBonus_X[this.stScore[i].nPlayer] + xAdd, CDTXMania.Skin.Game_Score_AddBonus_Y[ this.stScore[ i ].nPlayer ], string.Format( "{0,7:######0}", this.stScore[ i ].nAddScore ), this.stScore[ i ].nPlayer + 1 , alpha, stScore[i].nPlayer);
                            else
                            {
                                this.n現在表示中のAddScore--;
                                this.stScore[ i ].b表示中 = false;
                            }
                        }
                    }
                    //CDTXMania.act文字コンソール.tPrint(50, 0, C文字コンソール.Eフォント種別.白, this.ct点数アニメタイマ[0].n現在の値.ToString());
                    //CDTXMania.act文字コンソール.tPrint(50, 20, C文字コンソール.Eフォント種別.白, this.ct点数アニメタイマ[0].b進行中.ToString());
                }


                //this.n現在表示中のスコア.Taiko = (long)this.n現在の本当のスコア.Taiko;

                //string str = this.n現在表示中のスコア.Taiko.ToString( "0000000" );
                //for ( int i = 0; i < 7; i++ )
                //{
                //    Rectangle rectangle;
                //    char ch = str[i];
                //    if( ch.Equals(' ') )
                //    {
                //        rectangle = new Rectangle(0, 0, 24, 34);
                //    }
                //    else
                //    {
                //        int num4 = int.Parse(str.Substring(i, 1));
                //        rectangle = new Rectangle(num4 * 24, 0, 24, 34);
                //    }
                //    if( base.txScore != null )
                //    {
                //        base.txScore.t2D描画(CDTXMania.app.Device, 20 + (i * 20), 192, rectangle);
                //    }
                //}


                //CDTXMania.act文字コンソール.tPrint( 50, 200, C文字コンソール.Eフォント種別.白, str  );
            }
            return 0;
        }
	}
}

