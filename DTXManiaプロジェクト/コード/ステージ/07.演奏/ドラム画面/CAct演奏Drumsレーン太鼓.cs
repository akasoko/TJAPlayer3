using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Diagnostics;
using SlimDX;
using FDK;

namespace DTXMania
{
    internal class CAct演奏Drumsレーン太鼓 : CActivity
    {
        /// <summary>
        /// レーンを描画するクラス。
        /// 
        /// 
        /// </summary>
        public CAct演奏Drumsレーン太鼓()
        {
            base.b活性化してない = true;
        }
        public void Start(int nLane, float f強弱度合い, int player)
        {
            int num = (int)((1f - f強弱度合い) * 55f);
            this.ct進行2[nLane + (3 * player)] = new CCounter(0, 100, 2, CDTXMania.Timer);
            //if( nLane == 0 )
            //{
            //    this.ct進行[ 0 + ( 3 * player ) ] = new CCounter( 0, 100, 2, CDTXMania.Timer );
            //}
            //else if( nLane == 1 )
            //{
            //    this.ct進行[ 1 + ( 3 * player ) ] = new CCounter( 0, 100, 2, CDTXMania.Timer );
            //}
            //else if( nLane == 2 )
            //{
            //    this.ct進行[ 2 + ( 3 * player ) ] = new CCounter( 0, 100, 2, CDTXMania.Timer );
            //}

        }
        public override void On活性化()
        {
            for (int i = 0; i < 4; i++)
            {
                this.st状態[i].ct進行 = new CCounter();
                this.stBranch[i].ct分岐アニメ進行 = new CCounter();
                this.stBranch[i].nフラッシュ制御タイマ = -1;
                this.stBranch[i].nBranchレイヤー透明度 = 0;
                this.stBranch[i].nBranch文字透明度 = 0;
                this.stBranch[i].nY座標 = 0;
            }
            this.ctゴーゴー = new CCounter();
            this.ctゴーゴースプラッシュ = new CCounter();
            for (int i = 0; i < 12; i++)
            {
                this.ct進行2[i] = new CCounter();
            }

            this.n総移動時間 = -1;
            this.nDefaultJudgePos[0] = CDTXMania.Skin.nScrollFieldX[0];
            this.nDefaultJudgePos[1] = CDTXMania.Skin.nScrollFieldY[0];
            this.ctゴーゴー炎 = new CCounter(0, 6, 50, CDTXMania.Timer);
            this.ctゴーゴースプラッシュ = new CCounter(0, 28, 30, CDTXMania.Timer);
            base.On活性化();
        }

        public override void On非活性化()
        {
            for (int i = 0; i < 12; i++)
            {
                this.ct進行2[i] = null;
            }
            for (int i = 0; i < 4; i++)
            {
                this.st状態[i].ct進行 = null;
                this.stBranch[i].ct分岐アニメ進行 = null;
            }
            CDTXMania.Skin.nScrollFieldX[0] = this.nDefaultJudgePos[0];
            CDTXMania.Skin.nScrollFieldY[0] = this.nDefaultJudgePos[1];
            this.ctゴーゴー = null;
            this.ctゴーゴースプラッシュ = null;

            base.On非活性化();
        }

        public override void OnManagedリソースの作成()
        {
            //this.txLane = CDTXMania.tテクスチャの生成(CSkin.Path(@"Graphics\7_fieldbgA.png"));
            //this.txLaneB = CDTXMania.tテクスチャの生成(CSkin.Path(@"Graphics\7_fieldbgB.png"));
            //this.txゴーゴー = CDTXMania.tテクスチャの生成(CSkin.Path(@"Graphics\7_fieldbgC.png"));
            //this.tx普通譜面[0] = CDTXMania.tテクスチャの生成(CSkin.Path(@"Graphics\7_field_normal_base.png"));
            //this.tx玄人譜面[0] = CDTXMania.tテクスチャの生成(CSkin.Path(@"Graphics\7_field_expert_base.png"));
            //this.tx達人譜面[0] = CDTXMania.tテクスチャの生成(CSkin.Path(@"Graphics\7_field_master_base.png"));
            //this.tx普通譜面[1] = CDTXMania.tテクスチャの生成(CSkin.Path(@"Graphics\7_field_normal.png"));
            //this.tx玄人譜面[1] = CDTXMania.tテクスチャの生成(CSkin.Path(@"Graphics\7_field_expert.png"));
            //this.tx達人譜面[1] = CDTXMania.tテクスチャの生成(CSkin.Path(@"Graphics\7_field_master.png"));
            //this.tx枠線 = CDTXMania.tテクスチャの生成(CSkin.Path(@"Graphics\7_mtaiko_B.png"));
            //this.tx判定枠 = CDTXMania.tテクスチャの生成(CSkin.Path(@"Graphics\7_taiko_notes.png"));
            //this.txアタックエフェクトLower = CDTXMania.tテクスチャの生成Af( CSkin.Path( @"Graphics\7_explosion_lower.png" ) );

            //this.txゴーゴー炎 = CDTXMania.tテクスチャの生成(CSkin.Path(@"Graphics\7_gogo_fire.png"));

            //this.txゴーゴースプラッシュ = new CTexture[29];
            //for (int i = 0; i < 29; i++)
            //{
            //    this.txゴーゴースプラッシュ[i] = CDTXMania.tテクスチャの生成(CSkin.Path(@"Graphics\Dancer\gogo_splash\" + i.ToString() + ".png"));
            //    this.txゴーゴースプラッシュ[i].b加算合成 = true;
            //}

            //this.txArアタックエフェクトLower_A = new CTexture[15];
            //this.txArアタックエフェクトLower_B = new CTexture[15];
            //this.txArアタックエフェクトLower_C = new CTexture[15];
            //this.txArアタックエフェクトLower_D = new CTexture[15];
            //for (int i = 0; i < 15; i++)
            //{
            //    this.txArアタックエフェクトLower_A[i] = CDTXMania.tテクスチャの生成(CSkin.Path(@"Graphics\Effect\lower_1_" + i.ToString() + ".png"));
            //    this.txArアタックエフェクトLower_B[i] = CDTXMania.tテクスチャの生成(CSkin.Path(@"Graphics\Effect\lower_2_" + i.ToString() + ".png"));
            //    this.txArアタックエフェクトLower_C[i] = CDTXMania.tテクスチャの生成(CSkin.Path(@"Graphics\Effect\lower_3_" + i.ToString() + ".png"));
            //    this.txArアタックエフェクトLower_D[i] = CDTXMania.tテクスチャの生成(CSkin.Path(@"Graphics\Effect\lower_4_" + i.ToString() + ".png"));

            //    //this.txArアタックエフェクトLower_A[ i ].b加算合成 = true;
            //    //this.txArアタックエフェクトLower_B[ i ].b加算合成 = true;
            //    //this.txArアタックエフェクトLower_C[ i ].b加算合成 = true;
            //    //this.txArアタックエフェクトLower_D[ i ].b加算合成 = true;
            //}
            base.OnManagedリソースの作成();
        }

        public override void OnManagedリソースの解放()
        {
            //CDTXMania.tテクスチャの解放(ref this.txLane);
            //CDTXMania.tテクスチャの解放(ref this.txLaneB);
            //CDTXMania.tテクスチャの解放(ref this.txゴーゴー);
            //CDTXMania.tテクスチャの解放(ref this.tx普通譜面[0]);
            //CDTXMania.tテクスチャの解放(ref this.tx玄人譜面[0]);
            //CDTXMania.tテクスチャの解放(ref this.tx達人譜面[0]);
            //CDTXMania.tテクスチャの解放(ref this.tx普通譜面[1]);
            //CDTXMania.tテクスチャの解放(ref this.tx玄人譜面[1]);
            //CDTXMania.tテクスチャの解放(ref this.tx達人譜面[1]);

            //CDTXMania.tテクスチャの解放(ref this.tx枠線);
            //CDTXMania.tテクスチャの解放(ref this.tx判定枠);
            ////CDTXMania.tテクスチャの解放( ref this.txアタックエフェクトLower );

            //CDTXMania.tテクスチャの解放(ref this.txゴーゴー炎);

            //for (int i = 0; i < 29; i++)
            //{
            //    CDTXMania.tテクスチャの解放(ref this.txゴーゴースプラッシュ[i]);
            //}

            //for (int i = 0; i < 15; i++)
            //{
            //    CDTXMania.tテクスチャの解放(ref this.txArアタックエフェクトLower_A[i]);
            //    CDTXMania.tテクスチャの解放(ref this.txArアタックエフェクトLower_B[i]);
            //    CDTXMania.tテクスチャの解放(ref this.txArアタックエフェクトLower_C[i]);
            //    CDTXMania.tテクスチャの解放(ref this.txArアタックエフェクトLower_D[i]);
            //}

            base.OnManagedリソースの解放();
        }

        public override int On進行描画()
        {
            if (base.b初めての進行描画)
            {
                for (int i = 0; i < 4; i++)
                    this.stBranch[i].nフラッシュ制御タイマ = FDK.CSound管理.rc演奏用タイマ.n現在時刻;
                base.b初めての進行描画 = false;
            }

            //それぞれが独立したレイヤーでないといけないのでforループはパーツごとに分離すること。

            #region[ レーン本体 ]
            if (CDTXMania.Tx.Lane_Background_Main != null)
            {
                for (int i = 0; i < CDTXMania.ConfigIni.nPlayerCount; i++)
                {
                    CDTXMania.Tx.Lane_Background_Main.t2D描画(CDTXMania.app.Device, CDTXMania.Skin.nScrollFieldBGX[i], CDTXMania.Skin.nScrollFieldY[i]);
                }
            }
            #endregion
            for (int i = 0; i < CDTXMania.ConfigIni.nPlayerCount; i++)
            {
                #region[ 分岐アニメ制御タイマー ]
                long num = FDK.CSound管理.rc演奏用タイマ.n現在時刻;
                if (num < this.stBranch[i].nフラッシュ制御タイマ)
                {
                    this.stBranch[i].nフラッシュ制御タイマ = num;
                }
                while ((num - this.stBranch[i].nフラッシュ制御タイマ) >= 30)
                {
                    if (this.stBranch[i].nBranchレイヤー透明度 <= 255)
                    {
                        this.stBranch[i].nBranchレイヤー透明度 += 10;
                    }

                    if (this.stBranch[i].nBranch文字透明度 >= 0)
                    {
                        this.stBranch[i].nBranch文字透明度 -= 10;
                    }

                    if (this.stBranch[i].nY座標 != 0 && this.stBranch[i].nY座標 <= 20)
                    {
                        this.stBranch[i].nY座標++;
                    }

                    this.stBranch[i].nフラッシュ制御タイマ += 8;
                }

                if (!this.stBranch[i].ct分岐アニメ進行.b停止中)
                {
                    this.stBranch[i].ct分岐アニメ進行.t進行();
                    if (this.stBranch[i].ct分岐アニメ進行.b終了値に達した)
                    {
                        this.stBranch[i].ct分岐アニメ進行.t停止();
                    }
                }
                #endregion
            }
            #region[ 分岐レイヤー ]
            for (int i = 0; i < CDTXMania.ConfigIni.nPlayerCount; i++)
            {
                if (CDTXMania.stage演奏ドラム画面.bUseBranch[i] == true)
                {
                    #region[ 動いていない ]
                    switch (CDTXMania.stage演奏ドラム画面.n次回のコース[i])
                    {
                        case 0:
                            if (CDTXMania.Tx.Lane_Base[0] != null)
                            {
                                CDTXMania.Tx.Lane_Base[0].n透明度 = 255;
                                CDTXMania.Tx.Lane_Base[0].t2D描画(CDTXMania.app.Device, CDTXMania.Skin.nScrollFieldBGX[i], CDTXMania.Skin.nScrollFieldY[i]);
                            }
                            break;
                        case 1:
                            if (CDTXMania.Tx.Lane_Base[1] != null)
                            {
                                CDTXMania.Tx.Lane_Base[1].n透明度 = 255;
                                CDTXMania.Tx.Lane_Base[1].t2D描画(CDTXMania.app.Device, CDTXMania.Skin.nScrollFieldBGX[i], CDTXMania.Skin.nScrollFieldY[i]);
                            }
                            break;
                        case 2:
                            if (CDTXMania.Tx.Lane_Base[2] != null)
                            {
                                CDTXMania.Tx.Lane_Base[2].n透明度 = 255;
                                CDTXMania.Tx.Lane_Base[2].t2D描画(CDTXMania.app.Device, CDTXMania.Skin.nScrollFieldBGX[i], CDTXMania.Skin.nScrollFieldY[i]);
                            }
                            break;
                    }
                    #endregion

                    if (CDTXMania.ConfigIni.nBranchAnime == 1)
                    {
                        #region[ AC7～14風の背後レイヤー ]
                        if (this.stBranch[i].ct分岐アニメ進行.b進行中)
                        {
                            int n透明度 = ((100 - this.stBranch[i].ct分岐アニメ進行.n現在の値) * 0xff) / 100;

                            if (this.stBranch[i].ct分岐アニメ進行.b終了値に達した)
                            {
                                n透明度 = 255;
                                this.stBranch[i].ct分岐アニメ進行.t停止();
                            }

                            #region[ 普通譜面_レベルアップ ]
                            //普通→玄人
                            if (this.stBranch[i].nBefore == 0 && this.stBranch[i].nAfter == 1)
                            {
                                if (CDTXMania.Tx.Lane_Base[0] != null && CDTXMania.Tx.Lane_Base[1] != null)
                                {
                                    CDTXMania.Tx.Lane_Base[0].t2D描画(CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[i]);
                                    CDTXMania.Tx.Lane_Base[1].n透明度 = this.stBranch[i].nBranchレイヤー透明度;
                                    CDTXMania.Tx.Lane_Base[1].t2D描画(CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[i]);
                                }
                            }
                            //普通→達人
                            if (this.stBranch[i].nBefore == 0 && this.stBranch[i].nAfter == 2)
                            {
                                if (this.stBranch[i].ct分岐アニメ進行.n現在の値 < 100)
                                {
                                    n透明度 = ((100 - this.stBranch[i].ct分岐アニメ進行.n現在の値) * 0xff) / 100;
                                }
                                if (CDTXMania.Tx.Lane_Base[0] != null && CDTXMania.Tx.Lane_Base[2] != null)
                                {
                                    CDTXMania.Tx.Lane_Base[0].t2D描画(CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[i]);
                                    CDTXMania.Tx.Lane_Base[2].t2D描画(CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[i]);
                                    CDTXMania.Tx.Lane_Base[2].n透明度 = this.stBranch[i].nBranchレイヤー透明度;
                                }
                            }
                            #endregion
                            #region[ 玄人譜面_レベルアップ ]
                            if (this.stBranch[i].nBefore == 1 && this.stBranch[i].nAfter == 2)
                            {
                                if (CDTXMania.Tx.Lane_Base[1] != null && CDTXMania.Tx.Lane_Base[2] != null)
                                {
                                    CDTXMania.Tx.Lane_Base[1].t2D描画(CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[i]);
                                    CDTXMania.Tx.Lane_Base[2].t2D描画(CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[i]);
                                    CDTXMania.Tx.Lane_Base[2].n透明度 = this.stBranch[i].nBranchレイヤー透明度;
                                }
                            }
                            #endregion
                            #region[ 玄人譜面_レベルダウン ]
                            if (this.stBranch[i].nBefore == 1 && this.stBranch[i].nAfter == 0)
                            {
                                if (CDTXMania.Tx.Lane_Base[1] != null && CDTXMania.Tx.Lane_Base[0] != null)
                                {
                                    CDTXMania.Tx.Lane_Base[1].t2D描画(CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[i]);
                                    CDTXMania.Tx.Lane_Base[0].t2D描画(CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[i]);
                                    CDTXMania.Tx.Lane_Base[0].n透明度 = this.stBranch[i].nBranchレイヤー透明度;
                                }
                            }
                            #endregion
                            #region[ 達人譜面_レベルダウン ]
                            if (this.stBranch[i].nBefore == 2 && this.stBranch[i].nAfter == 0)
                            {
                                if (CDTXMania.Tx.Lane_Base[2] != null && CDTXMania.Tx.Lane_Base[0] != null)
                                {
                                    CDTXMania.Tx.Lane_Base[2].t2D描画(CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[i]);
                                    CDTXMania.Tx.Lane_Base[0].t2D描画(CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[i]);
                                    CDTXMania.Tx.Lane_Base[0].n透明度 = this.stBranch[i].nBranchレイヤー透明度;
                                }
                            }
                            #endregion
                        }
                        #endregion
                    }
                    else if (CDTXMania.ConfigIni.nBranchAnime == 0)
                    {
                        CDTXMania.stage演奏ドラム画面.actLane.On進行描画();
                    }
                }
            }
            #endregion
            for (int i = 0; i < CDTXMania.ConfigIni.nPlayerCount; i++)
            {
                #region[ ゴーゴータイムレーン背景レイヤー ]
                if (CDTXMania.Tx.Lane_Background_GoGo != null && CDTXMania.stage演奏ドラム画面.bIsGOGOTIME[i])
                {
                    if (!this.ctゴーゴー.b停止中)
                    {
                        this.ctゴーゴー.t進行();
                    }

                    if (this.ctゴーゴー.n現在の値 <= 4)
                    {
                        CDTXMania.Tx.Lane_Background_GoGo.vc拡大縮小倍率.Y = 0.2f;
                        CDTXMania.Tx.Lane_Background_GoGo.t2D描画(CDTXMania.app.Device, CDTXMania.Skin.nScrollFieldBGX[i], CDTXMania.Skin.nScrollFieldY[i] + 54);
                    }
                    else if (this.ctゴーゴー.n現在の値 <= 5)
                    {
                        CDTXMania.Tx.Lane_Background_GoGo.vc拡大縮小倍率.Y = 0.4f;
                        CDTXMania.Tx.Lane_Background_GoGo.t2D描画(CDTXMania.app.Device, CDTXMania.Skin.nScrollFieldBGX[i], CDTXMania.Skin.nScrollFieldY[i] + 40);
                    }
                    else if (this.ctゴーゴー.n現在の値 <= 6)
                    {
                        CDTXMania.Tx.Lane_Background_GoGo.vc拡大縮小倍率.Y = 0.6f;
                        CDTXMania.Tx.Lane_Background_GoGo.t2D描画(CDTXMania.app.Device, CDTXMania.Skin.nScrollFieldBGX[i], CDTXMania.Skin.nScrollFieldY[i] + 26);
                    }
                    else if (this.ctゴーゴー.n現在の値 <= 8)
                    {
                        CDTXMania.Tx.Lane_Background_GoGo.vc拡大縮小倍率.Y = 0.8f;
                        CDTXMania.Tx.Lane_Background_GoGo.t2D描画(CDTXMania.app.Device, CDTXMania.Skin.nScrollFieldBGX[i], CDTXMania.Skin.nScrollFieldY[i] + 13);
                    }
                    else if (this.ctゴーゴー.n現在の値 >= 9)
                    {
                        CDTXMania.Tx.Lane_Background_GoGo.vc拡大縮小倍率.Y = 1.0f;
                        CDTXMania.Tx.Lane_Background_GoGo.t2D描画(CDTXMania.app.Device, CDTXMania.Skin.nScrollFieldBGX[i], CDTXMania.Skin.nScrollFieldY[i]);
                    }
                }
                #endregion
            }
            
            for (int i = 0; i < CDTXMania.ConfigIni.nPlayerCount; i++)
            {
                if (CDTXMania.stage演奏ドラム画面.bUseBranch[i] == true)
                {
                    if (CDTXMania.ConfigIni.nBranchAnime == 0)
                    {
                        if (!this.stBranch[i].ct分岐アニメ進行.b進行中)
                        {
                            switch (CDTXMania.stage演奏ドラム画面.n次回のコース[i])
                            {
                                case 0:
                                    CDTXMania.Tx.Lane_Text[0].n透明度 = 255;
                                    CDTXMania.Tx.Lane_Text[0].t2D描画(CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[i]);
                                    break;
                                case 1:
                                    CDTXMania.Tx.Lane_Text[1].n透明度 = 255;
                                    CDTXMania.Tx.Lane_Text[1].t2D描画(CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[i]);
                                    break;
                                case 2:
                                    CDTXMania.Tx.Lane_Text[2].n透明度 = 255;
                                    CDTXMania.Tx.Lane_Text[2].t2D描画(CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[i]);
                                    break;
                            }
                        }
                        if (this.stBranch[i].ct分岐アニメ進行.b進行中)
                        {
                            #region[ 普通譜面_レベルアップ ]
                            //普通→玄人
                            if (this.stBranch[i].nBefore == 0 && this.stBranch[i].nAfter == 1)
                            {
                                CDTXMania.Tx.Lane_Text[0].n透明度 = 255;
                                CDTXMania.Tx.Lane_Text[1].n透明度 = 255;
                                CDTXMania.Tx.Lane_Text[2].n透明度 = 255;

                                CDTXMania.Tx.Lane_Text[0].n透明度 = this.stBranch[i].ct分岐アニメ進行.n現在の値 > 100 ? 0 : (255 - ((this.stBranch[i].ct分岐アニメ進行.n現在の値 * 0xff) / 60));
                                //CDTXMania.Tx.Lane_Text[1].n透明度 = this.ct分岐アニメ進行.n現在の値 > 100 ? 255 : ( ( ( this.ct分岐アニメ進行.n現在の値 * 0xff ) / 60 ) );
                                if (this.stBranch[i].ct分岐アニメ進行.n現在の値 < 60)
                                {
                                    this.stBranch[i].nY = this.stBranch[i].ct分岐アニメ進行.n現在の値 / 2;
                                    CDTXMania.Tx.Lane_Text[0].t2D描画(CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[i] + this.stBranch[i].nY);
                                    CDTXMania.Tx.Lane_Text[1].n透明度 = 255;
                                    CDTXMania.Tx.Lane_Text[1].t2D描画(CDTXMania.app.Device, 333, (CDTXMania.Skin.nScrollFieldY[i] - 30) + this.stBranch[i].nY);
                                }
                                else
                                {
                                    CDTXMania.Tx.Lane_Text[1].n透明度 = 255;
                                    CDTXMania.Tx.Lane_Text[1].t2D描画(CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[i]);
                                }

                            }

                            //普通→達人
                            if (this.stBranch[i].nBefore == 0 && this.stBranch[i].nAfter == 2)
                            {
                                CDTXMania.Tx.Lane_Text[0].n透明度 = 255;
                                CDTXMania.Tx.Lane_Text[1].n透明度 = 255;
                                CDTXMania.Tx.Lane_Text[2].n透明度 = 255;
                                if (this.stBranch[i].ct分岐アニメ進行.n現在の値 < 60)
                                {
                                    this.stBranch[i].nY = this.stBranch[i].ct分岐アニメ進行.n現在の値 / 2;
                                    CDTXMania.Tx.Lane_Text[0].t2D描画(CDTXMania.app.Device, 333, (CDTXMania.Skin.nScrollFieldY[i] - 12) + this.stBranch[i].nY);
                                    CDTXMania.Tx.Lane_Text[0].n透明度 = this.stBranch[i].ct分岐アニメ進行.n現在の値 > 100 ? 0 : (255 - ((this.stBranch[i].ct分岐アニメ進行.n現在の値 * 0xff) / 100));
                                    CDTXMania.Tx.Lane_Text[1].t2D描画(CDTXMania.app.Device, 333, (CDTXMania.Skin.nScrollFieldY[i] - 20) + this.stBranch[i].nY);
                                }
                                //if( this.stBranch[ i ].ct分岐アニメ進行.n現在の値 >= 5 && this.stBranch[ i ].ct分岐アニメ進行.n現在の値 < 60 )
                                //{
                                //    this.stBranch[ i ].nY = this.stBranch[ i ].ct分岐アニメ進行.n現在の値 / 2;
                                //    this.tx普通譜面[ 1 ].t2D描画(CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[ i ] + this.stBranch[ i ].nY);
                                //    this.tx普通譜面[ 1 ].n透明度 = this.stBranch[ i ].ct分岐アニメ進行.n現在の値 > 100 ? 0 : ( 255 - ( ( this.stBranch[ i ].ct分岐アニメ進行.n現在の値 * 0xff) / 100));
                                //    this.tx玄人譜面[ 1 ].t2D描画(CDTXMania.app.Device, 333, ( CDTXMania.Skin.nScrollFieldY[ i ] - 10 ) + this.stBranch[ i ].nY);
                                //}
                                else if (this.stBranch[i].ct分岐アニメ進行.n現在の値 >= 60 && this.stBranch[i].ct分岐アニメ進行.n現在の値 < 150)
                                {
                                    this.stBranch[i].nY = 21;
                                    CDTXMania.Tx.Lane_Text[1].t2D描画(CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[i]);
                                    CDTXMania.Tx.Lane_Text[1].n透明度 = 255;
                                    CDTXMania.Tx.Lane_Text[2].n透明度 = 255;
                                }
                                else if (this.stBranch[i].ct分岐アニメ進行.n現在の値 >= 150 && this.stBranch[i].ct分岐アニメ進行.n現在の値 < 210)
                                {
                                    this.stBranch[i].nY = ((this.stBranch[i].ct分岐アニメ進行.n現在の値 - 150) / 2);
                                    CDTXMania.Tx.Lane_Text[1].t2D描画(CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[i] + this.stBranch[i].nY);
                                    CDTXMania.Tx.Lane_Text[1].n透明度 = this.stBranch[i].ct分岐アニメ進行.n現在の値 > 100 ? 0 : (255 - ((this.stBranch[i].ct分岐アニメ進行.n現在の値 * 0xff) / 100));
                                    CDTXMania.Tx.Lane_Text[2].t2D描画(CDTXMania.app.Device, 333, (CDTXMania.Skin.nScrollFieldY[i] - 20) + this.stBranch[i].nY);
                                }
                                else
                                {
                                    CDTXMania.Tx.Lane_Text[2].n透明度 = 255;
                                    CDTXMania.Tx.Lane_Text[2].t2D描画(CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[i]);
                                }
                            }
                            #endregion
                            #region[ 玄人譜面_レベルアップ ]
                            //玄人→達人
                            if (this.stBranch[i].nBefore == 1 && this.stBranch[i].nAfter == 2)
                            {
                                CDTXMania.Tx.Lane_Text[0].n透明度 = 255;
                                CDTXMania.Tx.Lane_Text[1].n透明度 = 255;
                                CDTXMania.Tx.Lane_Text[2].n透明度 = 255;

                                CDTXMania.Tx.Lane_Text[1].n透明度 = this.stBranch[i].ct分岐アニメ進行.n現在の値 > 100 ? 0 : (255 - ((this.stBranch[i].ct分岐アニメ進行.n現在の値 * 0xff) / 60));
                                if (this.stBranch[i].ct分岐アニメ進行.n現在の値 < 60)
                                {
                                    this.stBranch[i].nY = this.stBranch[i].ct分岐アニメ進行.n現在の値 / 2;
                                    CDTXMania.Tx.Lane_Text[1].t2D描画(CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[i] + this.stBranch[i].nY);
                                    CDTXMania.Tx.Lane_Text[2].t2D描画(CDTXMania.app.Device, 333, (CDTXMania.Skin.nScrollFieldY[i] - 20) + this.stBranch[i].nY);
                                }
                                else
                                {
                                    CDTXMania.Tx.Lane_Text[2].t2D描画(CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[i]);
                                }
                            }
                            #endregion
                            #region[ 玄人譜面_レベルダウン ]
                            if (this.stBranch[i].nBefore == 1 && this.stBranch[i].nAfter == 0)
                            {
                                CDTXMania.Tx.Lane_Text[0].n透明度 = 255;
                                CDTXMania.Tx.Lane_Text[1].n透明度 = 255;
                                CDTXMania.Tx.Lane_Text[2].n透明度 = 255;

                                CDTXMania.Tx.Lane_Text[1].n透明度 = this.stBranch[i].ct分岐アニメ進行.n現在の値 > 100 ? 0 : (255 - ((this.stBranch[i].ct分岐アニメ進行.n現在の値 * 0xff) / 60));
                                if (this.stBranch[i].ct分岐アニメ進行.n現在の値 < 60)
                                {
                                    this.stBranch[i].nY = this.stBranch[i].ct分岐アニメ進行.n現在の値 / 2;
                                    CDTXMania.Tx.Lane_Text[1].t2D描画(CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[i] - this.stBranch[i].nY);
                                    CDTXMania.Tx.Lane_Text[0].t2D描画(CDTXMania.app.Device, 333, (CDTXMania.Skin.nScrollFieldY[i] + 30) - this.stBranch[i].nY);
                                }
                                else
                                {
                                    CDTXMania.Tx.Lane_Text[0].t2D描画(CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[i]);
                                }
                            }
                            #endregion
                            #region[ 達人譜面_レベルダウン ]
                            if (this.stBranch[i].nBefore == 2 && this.stBranch[i].nAfter == 0)
                            {
                                CDTXMania.Tx.Lane_Text[0].n透明度 = 255;
                                CDTXMania.Tx.Lane_Text[1].n透明度 = 255;
                                CDTXMania.Tx.Lane_Text[2].n透明度 = 255;

                                if (this.stBranch[i].ct分岐アニメ進行.n現在の値 < 60)
                                {
                                    this.stBranch[i].nY = this.stBranch[i].ct分岐アニメ進行.n現在の値 / 2;
                                    CDTXMania.Tx.Lane_Text[2].n透明度 = this.stBranch[i].ct分岐アニメ進行.n現在の値 > 100 ? 0 : (255 - ((this.stBranch[i].ct分岐アニメ進行.n現在の値 * 0xff) / 60));
                                    CDTXMania.Tx.Lane_Text[2].t2D描画(CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[i] - this.stBranch[i].nY);
                                    CDTXMania.Tx.Lane_Text[1].t2D描画(CDTXMania.app.Device, 333, (CDTXMania.Skin.nScrollFieldY[i] + 30) - this.stBranch[i].nY);
                                }
                                else if (this.stBranch[i].ct分岐アニメ進行.n現在の値 >= 60 && this.stBranch[i].ct分岐アニメ進行.n現在の値 < 150)
                                {
                                    this.stBranch[i].nY = 21;
                                    CDTXMania.Tx.Lane_Text[1].t2D描画(CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[i]);
                                    CDTXMania.Tx.Lane_Text[1].n透明度 = 255;
                                    CDTXMania.Tx.Lane_Text[2].n透明度 = 255;
                                }
                                else if (this.stBranch[i].ct分岐アニメ進行.n現在の値 >= 150 && this.stBranch[i].ct分岐アニメ進行.n現在の値 < 210)
                                {
                                    this.stBranch[i].nY = ((this.stBranch[i].ct分岐アニメ進行.n現在の値 - 150) / 2);
                                    CDTXMania.Tx.Lane_Text[1].t2D描画(CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[i] - this.stBranch[i].nY);
                                    CDTXMania.Tx.Lane_Text[1].n透明度 = this.stBranch[i].ct分岐アニメ進行.n現在の値 > 100 ? 0 : (255 - ((this.stBranch[i].ct分岐アニメ進行.n現在の値 * 0xff) / 100));
                                    CDTXMania.Tx.Lane_Text[0].t2D描画(CDTXMania.app.Device, 333, (CDTXMania.Skin.nScrollFieldY[i] + 30) - this.stBranch[i].nY);
                                }
                                else if (this.stBranch[i].ct分岐アニメ進行.n現在の値 >= 210)
                                {
                                    CDTXMania.Tx.Lane_Text[0].n透明度 = 255;
                                    CDTXMania.Tx.Lane_Text[0].t2D描画(CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[i]);
                                }
                            }
                            if (this.stBranch[i].nBefore == 2 && this.stBranch[i].nAfter == 1)
                            {
                                CDTXMania.Tx.Lane_Text[0].n透明度 = 255;
                                CDTXMania.Tx.Lane_Text[1].n透明度 = 255;
                                CDTXMania.Tx.Lane_Text[2].n透明度 = 255;

                                CDTXMania.Tx.Lane_Text[2].n透明度 = this.stBranch[i].ct分岐アニメ進行.n現在の値 > 100 ? 0 : (255 - ((this.stBranch[i].ct分岐アニメ進行.n現在の値 * 0xff) / 60));
                                if (this.stBranch[i].ct分岐アニメ進行.n現在の値 < 60)
                                {
                                    this.stBranch[i].nY = this.stBranch[i].ct分岐アニメ進行.n現在の値 / 2;
                                    CDTXMania.Tx.Lane_Text[2].t2D描画(CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[i] - this.stBranch[i].nY);
                                    CDTXMania.Tx.Lane_Text[1].t2D描画(CDTXMania.app.Device, 333, (CDTXMania.Skin.nScrollFieldY[i] + 30) - this.stBranch[i].nY);
                                }
                                else
                                {
                                    CDTXMania.Tx.Lane_Text[1].t2D描画(CDTXMania.app.Device, 333, CDTXMania.Skin.nScrollFieldY[i]);
                                }

                            }
                            #endregion
                        }
                    }
                    else
                    {
                        if (this.stBranch[i].nY座標 == 21)
                        {
                            this.stBranch[i].nY座標 = 0;
                        }

                        if (this.stBranch[i].nY座標 == 0)
                        {
                            switch (CDTXMania.stage演奏ドラム画面.n次回のコース[0])
                            {
                                case 0:
                                    CDTXMania.Tx.Lane_Text[0].n透明度 = 255;
                                    CDTXMania.Tx.Lane_Text[0].t2D描画(CDTXMania.app.Device, 333, 192);
                                    break;
                                case 1:
                                    CDTXMania.Tx.Lane_Text[1].n透明度 = 255;
                                    CDTXMania.Tx.Lane_Text[1].t2D描画(CDTXMania.app.Device, 333, 192);
                                    break;
                                case 2:
                                    CDTXMania.Tx.Lane_Text[2].n透明度 = 255;
                                    CDTXMania.Tx.Lane_Text[2].t2D描画(CDTXMania.app.Device, 333, 192);
                                    break;
                            }
                        }


                        if (this.stBranch[i].nY座標 != 0)
                        {
                            #region[ 普通譜面_レベルアップ ]
                            //普通→玄人
                            if (this.stBranch[i].nBefore == 0 && this.stBranch[i].nAfter == 1)
                            {
                                CDTXMania.Tx.Lane_Text[0].t2D描画(CDTXMania.app.Device, 333, 192 - this.stBranch[i].nY座標);
                                CDTXMania.Tx.Lane_Text[1].t2D描画(CDTXMania.app.Device, 333, 212 - this.stBranch[i].nY座標);
                                CDTXMania.Tx.Lane_Text[0].n透明度 = this.stBranch[i].nBranchレイヤー透明度;
                            }
                            //普通→達人
                            if (this.stBranch[i].nBefore == 0 && this.stBranch[i].nAfter == 2)
                            {
                                CDTXMania.Tx.Lane_Text[0].t2D描画(CDTXMania.app.Device, 333, 192 - this.stBranch[i].nY座標);
                                CDTXMania.Tx.Lane_Text[2].t2D描画(CDTXMania.app.Device, 333, 212 - this.stBranch[i].nY座標);
                                CDTXMania.Tx.Lane_Text[0].n透明度 = this.stBranch[i].nBranchレイヤー透明度;
                            }
                            #endregion
                            #region[ 玄人譜面_レベルアップ ]
                            //玄人→達人
                            if (this.stBranch[i].nBefore == 1 && this.stBranch[i].nAfter == 2)
                            {
                                CDTXMania.Tx.Lane_Text[1].t2D描画(CDTXMania.app.Device, 333, 192 - this.stBranch[i].nY座標);
                                CDTXMania.Tx.Lane_Text[2].t2D描画(CDTXMania.app.Device, 333, 212 - this.stBranch[i].nY座標);
                                CDTXMania.Tx.Lane_Text[1].n透明度 = this.stBranch[i].nBranchレイヤー透明度;
                            }
                            #endregion
                            #region[ 玄人譜面_レベルダウン ]
                            if (this.stBranch[i].nBefore == 1 && this.stBranch[i].nAfter == 0)
                            {
                                CDTXMania.Tx.Lane_Text[1].t2D描画(CDTXMania.app.Device, 333, 192 + this.stBranch[i].nY座標);
                                CDTXMania.Tx.Lane_Text[0].t2D描画(CDTXMania.app.Device, 333, 168 + this.stBranch[i].nY座標);
                                CDTXMania.Tx.Lane_Text[1].n透明度 = this.stBranch[i].nBranchレイヤー透明度;
                            }
                            #endregion
                            #region[ 達人譜面_レベルダウン ]
                            if (this.stBranch[i].nBefore == 2 && this.stBranch[i].nAfter == 0)
                            {
                                CDTXMania.Tx.Lane_Text[2].t2D描画(CDTXMania.app.Device, 333, 192 + this.stBranch[i].nY座標);
                                CDTXMania.Tx.Lane_Text[0].t2D描画(CDTXMania.app.Device, 333, 168 + this.stBranch[i].nY座標);
                                CDTXMania.Tx.Lane_Text[2].n透明度 = this.stBranch[i].nBranchレイヤー透明度;
                            }
                            if (this.stBranch[i].nBefore == 2 && this.stBranch[i].nAfter == 1)
                            {
                                CDTXMania.Tx.Lane_Text[2].t2D描画(CDTXMania.app.Device, 333, 192 + this.stBranch[i].nY座標);
                                CDTXMania.Tx.Lane_Text[1].t2D描画(CDTXMania.app.Device, 333, 168 + this.stBranch[i].nY座標);
                                CDTXMania.Tx.Lane_Text[2].n透明度 = this.stBranch[i].nBranchレイヤー透明度;
                            }
                            #endregion
                        }
                    }

                }
            }



            if (CDTXMania.Tx.Lane_Background_Sub != null)
            {
                CDTXMania.Tx.Lane_Background_Sub.t2D描画(CDTXMania.app.Device, 333, 326);
                if (CDTXMania.stage演奏ドラム画面.bDoublePlay)
                {
                    CDTXMania.Tx.Lane_Background_Sub.t2D描画(CDTXMania.app.Device, 333, 502);
                }
            }


            CDTXMania.stage演奏ドラム画面.actLaneFlushD.On進行描画();



            if (CDTXMania.Tx.Taiko_Frame[0] != null)
            {
                CDTXMania.Tx.Taiko_Frame[0].t2D描画(CDTXMania.app.Device, 329, 136, new Rectangle(0, 0, 951, 224));

                if (CDTXMania.stage演奏ドラム画面.bDoublePlay)
                {
                    if(CDTXMania.Tx.Taiko_Frame[1] != null)
                    {
                        CDTXMania.Tx.Taiko_Frame[1].t2D描画(CDTXMania.app.Device, 329, 360, new Rectangle(0, 224, 951, 224));
                    }
                }
            }


            if (this.n総移動時間 != -1)
            {
                if (n移動方向 == 1)
                    CDTXMania.Skin.nScrollFieldX[0] = this.n移動開始X + (int)((((int)CSound管理.rc演奏用タイマ.n現在時刻ms - this.n移動開始時刻) / (double)(this.n総移動時間)) * this.n移動距離px);
                else
                    CDTXMania.Skin.nScrollFieldX[0] = this.n移動開始X - (int)((((int)CSound管理.rc演奏用タイマ.n現在時刻ms - this.n移動開始時刻) / (double)(this.n総移動時間)) * this.n移動距離px);

                if (((int)CSound管理.rc演奏用タイマ.n現在時刻ms) > this.n移動開始時刻 + this.n総移動時間)
                {
                    this.n総移動時間 = -1;
                }
            }




            if (CDTXMania.ConfigIni.bAVI有効)
            {
                CDTXMania.Tx.Lane_Background_Main.n透明度 = 200;
                CDTXMania.Tx.Lane_Background_Sub.n透明度 = 200;
                CDTXMania.Tx.Lane_Background_GoGo.n透明度 = 200;
            }

            //CDTXMania.act文字コンソール.tPrint(0, 0, C文字コンソール.Eフォント種別.白, this.nBranchレイヤー透明度.ToString());
            //CDTXMania.act文字コンソール.tPrint(0, 16, C文字コンソール.Eフォント種別.白, this.ct分岐アニメ進行.n現在の値.ToString());
            //CDTXMania.act文字コンソール.tPrint(0, 32, C文字コンソール.Eフォント種別.白, this.ct分岐アニメ進行.n終了値.ToString());

            //CDTXMania.act文字コンソール.tPrint(0, 32, C文字コンソール.Eフォント種別.白, this.ctゴーゴースプラッシュ.n現在の値.ToString());

            /*#region[ ゴーゴースプラッシュ ]
            for (int i = 0; i < CDTXMania.ConfigIni.nPlayerCount; i++)
            {
                if (CDTXMania.stage演奏ドラム画面.bIsGOGOTIME[i])
                {

                    if (this.txゴーゴースプラッシュ != null)
                    {
                        this.txゴーゴースプラッシュ[(int)this.ctゴーゴースプラッシュ.db現在の値].t2D描画(CDTXMania.app.Device, 0, 260);
                        this.ctゴーゴースプラッシュ.n現在の値++;
                        if(this.ctゴーゴースプラッシュ.b終了値に達した)
                        {
                            this.ctゴーゴースプラッシュ.t停止();
                            this.ctゴーゴースプラッシュ.n現在の値 = 0;
                        }
                    }
                    
         
                    this.ctゴーゴースプラッシュ.t進行Loop();
                if (this.txゴーゴースプラッシュ != null)
                {
                    if (this.ctゴーゴースプラッシュ.b終了値に達してない)
                    {
                        this.txゴーゴースプラッシュ[(int)this.ctゴーゴースプラッシュ.db現在の値].t2D描画(CDTXMania.app.Device, 0, 260);
                    }

                }
                }
            }
            #endregion */
            /*
            for (int i = 0; i < CDTXMania.ConfigIni.nPlayerCount; i++)
            {
                #region[ ゴーゴースプラッシュ ]
                if (this.txゴーゴースプラッシュ != null && CDTXMania.stage演奏ドラム画面.bIsGOGOTIME[i])
                {
                    if (!this.ctゴーゴースプラッシュ.b停止中)
                    {
                        this.ctゴーゴースプラッシュ.t進行();
                    }
                    if (this.ctゴーゴースプラッシュ.n現在の値 < 28)
                    {
                        for (int v = 0; v < 6; v++)
                        {
                            this.txゴーゴースプラッシュ[this.ctゴーゴースプラッシュ.n現在の値].t2D描画(CDTXMania.app.Device, 0 + (v * 213), 260);
                        }

                    }
                    else
                    {
                        this.txゴーゴースプラッシュ[this.ctゴーゴースプラッシュ.n現在の値].n透明度 = 100;
                    }

                }
                #endregion
            } */
            return base.On進行描画();
        }

        public void ゴーゴー炎()
        {
            //判定枠
            if (CDTXMania.Tx.Notes != null)
            {
                int nJudgeX = CDTXMania.Skin.nScrollFieldX[0] - (130 / 2); //元の値は349なんだけど...
                int nJudgeY = CDTXMania.Skin.nScrollFieldY[0]; //元の値は349なんだけど...
                CDTXMania.Tx.Judge_Frame.b加算合成 = true;
                CDTXMania.Tx.Judge_Frame.t2D描画(CDTXMania.app.Device, nJudgeX, nJudgeY, new Rectangle(0, 0, 130, 130));

                if (CDTXMania.stage演奏ドラム画面.bDoublePlay)
                    CDTXMania.Tx.Judge_Frame.t2D描画(CDTXMania.app.Device, nJudgeX, nJudgeY + 176, new Rectangle(0, 0, 130, 130));
            }


            #region[ ゴーゴー炎 ]
            for (int i = 0; i < CDTXMania.ConfigIni.nPlayerCount; i++)
            {
                if (CDTXMania.stage演奏ドラム画面.bIsGOGOTIME[i])
                {
                    this.ctゴーゴー炎.t進行Loop();

                    if (CDTXMania.Tx.Effects_Fire != null)
                    {
                        float f倍率 = 1.0f;

                        float[] ar倍率 = new float[] { 0.8f, 1.2f, 1.7f, 2.5f, 2.3f, 2.2f, 2.0f, 1.8f, 1.7f, 1.6f, 1.6f, 1.5f, 1.5f, 1.4f, 1.3f, 1.2f, 1.1f, 1.0f };

                        f倍率 = ar倍率[this.ctゴーゴー.n現在の値];

                        Matrix mat = Matrix.Identity;
                        mat *= Matrix.Scaling(f倍率, f倍率, 1.0f);
                        mat *= Matrix.Translation(CDTXMania.Skin.nScrollFieldX[i] - SampleFramework.GameWindowSize.Width / 2.0f, -(CDTXMania.Skin.nJudgePointY[i] - SampleFramework.GameWindowSize.Height / 2.0f), 0f);

                        //this.txゴーゴー炎.b加算合成 = true;

                        //this.ctゴーゴー.n現在の値 = 6;
                        if (this.ctゴーゴー.b終了値に達した)
                        {
                            CDTXMania.Tx.Effects_Fire.t2D描画(CDTXMania.app.Device, CDTXMania.Skin.nScrollFieldX[i] - 180, CDTXMania.Skin.nJudgePointY[i] - (CDTXMania.Tx.Effects_Fire.szテクスチャサイズ.Height / 2), new Rectangle(360 * (this.ctゴーゴー炎.n現在の値), 0, 360, 370));
                        }
                        else
                        {
                            CDTXMania.Tx.Effects_Fire.t3D描画(CDTXMania.app.Device, mat, new Rectangle(360 * (this.ctゴーゴー炎.n現在の値), 0, 360, 370));
                        }
                    }
                }
            }
            #endregion
            for (int i = 0; i < CDTXMania.ConfigIni.nPlayerCount; i++)
            {
                if (!this.st状態[i].ct進行.b停止中)
                {
                    this.st状態[i].ct進行.t進行();
                    if (this.st状態[i].ct進行.b終了値に達した)
                    {
                        this.st状態[i].ct進行.t停止();
                    }
                    //if( this.txアタックエフェクトLower != null )
                    {
                        //this.txアタックエフェクトLower.b加算合成 = true;
                        int n = this.st状態[i].nIsBig == 1 ? 520 : 0;

                        switch (st状態[i].judge)
                        {
                            case E判定.Perfect:
                            case E判定.Great:
                            case E判定.Auto:
                                //this.txアタックエフェクトLower.t2D描画( CDTXMania.app.Device, 285, 127, new Rectangle( this.st状態[ i ].ct進行.n現在の値 * 260, n, 260, 260 ) );

                                int y;
                                int x_upper;
                                int x_lower;

                                // 位置決定。

                                //if( this.b要素値にフォーカス中 )
                                {

                                    x_upper = 372 - this.st状態[nPlayer].ct進行.n現在の値;

                                    x_lower = 800 + this.st状態[nPlayer].ct進行.n現在の値;

                                    y = 295;
                                }
                                //else
                                //{
                                //x = 276;	// 項目名の上下あたり。
                                //y_upper = 186 - this.ct三角矢印アニメ.n現在の値;
                                //y_lower = 254 + this.ct三角矢印アニメ.n現在の値;
                                //}

                                // 描画。
                                if (this.st状態[nPlayer].ct進行.n現在の値 < 1) CDTXMania.Tx.Effects_Hit_Great.n透明度 = 255;
                                else if (this.st状態[nPlayer].ct進行.n現在の値 >= 1 && this.st状態[nPlayer].ct進行.n現在の値 < 22) CDTXMania.Tx.Effects_Hit_Great.n透明度 = (int)(255 - (16 * this.st状態[nPlayer].ct進行.n現在の値));
                                if (this.st状態[nPlayer].ct進行.n現在の値 < 1) CDTXMania.Tx.Effects_Hit_Great_Big.n透明度 = 255;
                                else if (this.st状態[nPlayer].ct進行.n現在の値 >= 1 && this.st状態[nPlayer].ct進行.n現在の値 < 22) CDTXMania.Tx.Effects_Hit_Great_Big.n透明度 = (int)(255 - (16 * this.st状態[nPlayer].ct進行.n現在の値));
                                if (this.st状態[i].nIsBig == 1 && CDTXMania.Tx.Effects_Hit_Great_Big != null)
                                    CDTXMania.Tx.Effects_Hit_Great_Big.t2D描画( CDTXMania.app.Device, CDTXMania.Skin.nScrollFieldX[0] - CDTXMania.Tx.Effects_Hit_Good.szテクスチャサイズ.Width / 2, CDTXMania.Skin.nJudgePointY2[i] - CDTXMania.Tx.Effects_Hit_Good.n透明度 / 255);
                                else if (CDTXMania.Tx.Effects_Hit_Great != null)
                                    CDTXMania.Tx.Effects_Hit_Great.t2D描画(CDTXMania.app.Device, CDTXMania.Skin.nScrollFieldX[0] - CDTXMania.Tx.Effects_Hit_Good.szテクスチャサイズ.Width / 2, CDTXMania.Skin.nJudgePointY2[i] - CDTXMania.Tx.Effects_Hit_Good.n透明度 / 255);

                                break;



                            case E判定.Good:
                                //this.txアタックエフェクトLower.t2D描画( CDTXMania.app.Device, 285, 127, new Rectangle( this.st状態[ i ].ct進行.n現在の値 * 260, n + 260, 260, 260 ) );

                                #region[透明度制御]
                                if (this.st状態[nPlayer].ct進行.n現在の値 < 1) CDTXMania.Tx.Effects_Hit_Good.n透明度 = 255;
                                else if (this.st状態[nPlayer].ct進行.n現在の値 >= 1 && this.st状態[nPlayer].ct進行.n現在の値 < 22) CDTXMania.Tx.Effects_Hit_Good.n透明度 = (int)(255 - (16 * this.st状態[nPlayer].ct進行.n現在の値));
                                #endregion
                                #region[透明度制御]
                                if (this.st状態[nPlayer].ct進行.n現在の値 < 1) CDTXMania.Tx.Effects_Hit_Good_Big.n透明度 = 255;
                                else if (this.st状態[nPlayer].ct進行.n現在の値 >= 1 && this.st状態[nPlayer].ct進行.n現在の値 < 22) CDTXMania.Tx.Effects_Hit_Good_Big.n透明度 = (int)(255 - (16 * this.st状態[nPlayer].ct進行.n現在の値));
                                #endregion

                                if (this.st状態[i].nIsBig == 1 && CDTXMania.Tx.Effects_Hit_Good_Big != null)
                                    CDTXMania.Tx.Effects_Hit_Good_Big.t2D描画(CDTXMania.app.Device, CDTXMania.Skin.nScrollFieldX[0] - CDTXMania.Tx.Effects_Hit_Good_Big.szテクスチャサイズ.Width / 2, CDTXMania.Skin.nJudgePointY2[i] - CDTXMania.Tx.Effects_Hit_Good_Big.n透明度 / 255);
                                else if (CDTXMania.Tx.Effects_Hit_Good != null)
                                    CDTXMania.Tx.Effects_Hit_Good.t2D描画(CDTXMania.app.Device, CDTXMania.Skin.nScrollFieldX[0] - CDTXMania.Tx.Effects_Hit_Good.szテクスチャサイズ.Width / 2, CDTXMania.Skin.nJudgePointY2[i] - CDTXMania.Tx.Effects_Hit_Good.n透明度 / 255);

                                break;

                            case E判定.Miss:
                            case E判定.Bad:
                                break;
                        }
                    }
                }
            }


        }

        public virtual void Start(int nLane, E判定 judge, bool b両手入力, int nPlayer)
        {
            //2017.08.15 kairera0467 排他なので番地をそのまま各レーンの状態として扱う

            //for( int n = 0; n < 1; n++ )
            {
                this.st状態[nPlayer].ct進行 = new CCounter(0, 14, 20, CDTXMania.Timer);
                this.st状態[nPlayer].ct進行2 = new CCounter(0, 1, 143, CDTXMania.Timer);
                this.st状態[nPlayer].judge = judge;
                this.st状態[nPlayer].nPlayer = nPlayer;

                switch (nLane)
                {
                    case 0x11:
                    case 0x12:
                        this.st状態[nPlayer].nIsBig = 0;
                        break;
                    case 0x13:
                    case 0x14:
                    case 0x1A:
                    case 0x1B:
                        {
                            if (b両手入力)
                                this.st状態[nPlayer].nIsBig = 1;
                            else
                                this.st状態[nPlayer].nIsBig = 0;
                        }
                        break;
                }
            }
        }

        public void ゴーゴースプラッシュ()
        {
            if (CDTXMania.ConfigIni.nPlayerCount == 1)
            {
                #region[ ゴーゴースプラッシュ ]
                if (CDTXMania.Tx.Effects_Splash[0] != null && CDTXMania.stage演奏ドラム画面.bIsGOGOTIME[0])
                {
                    if (!this.ctゴーゴースプラッシュ.b停止中)
                    {
                        this.ctゴーゴースプラッシュ.t進行();
                    }
                    if (this.ctゴーゴースプラッシュ.n現在の値 < 28)
                    {
                        for (int v = 0; v < 6; v++)
                        {
                            CDTXMania.Tx.Effects_Splash[this.ctゴーゴースプラッシュ.n現在の値].t2D描画(CDTXMania.app.Device, 0 + (v * 213), 260);
                        }

                    }
                    else
                    {
                        CDTXMania.Tx.Effects_Splash[this.ctゴーゴースプラッシュ.n現在の値].n透明度 = 0;
                    }

                }
                #endregion
            }
            return;
        }

        public void GOGOSTART()
        {
            this.ctゴーゴー = new CCounter(0, 17, 18, CDTXMania.Timer);
            this.ctゴーゴースプラッシュ = new CCounter(0, 28, 15, CDTXMania.Timer);
            //if( this.ctゴーゴー.b停止中 )
            //this.ctゴーゴー.t進行();
            //this.ctゴーゴースプラッシュ = new CCounter(0, 29, 30, CDTXMania.Timer);
            //this.ctゴーゴースプラッシュ.t進行();
            //this.txゴーゴースプラッシュ[(int)this.ctゴーゴースプラッシュ.db現在の値].t2D描画(CDTXMania.app.Device, 0, 0);

        }


        public void t分岐レイヤー_コース変化(int n現在, int n次回, int nPlayer)
        {
            if (n現在 == n次回)
            {
                return;
            }
            this.stBranch[nPlayer].ct分岐アニメ進行 = new CCounter(0, 300, 2, CDTXMania.Timer);

            this.stBranch[nPlayer].nBranchレイヤー透明度 = 6;
            this.stBranch[nPlayer].nY座標 = 1;

            this.stBranch[nPlayer].nBefore = n現在;
            this.stBranch[nPlayer].nAfter = n次回;

            CDTXMania.stage演奏ドラム画面.actLane.t分岐レイヤー_コース変化(n現在, n次回, nPlayer);
        }

        public void t判定枠移動(double db移動時間, int n移動px, int n移動方向)
        {
            this.n移動開始時刻 = (int)CSound管理.rc演奏用タイマ.n現在時刻ms;
            this.n移動開始X = CDTXMania.Skin.nScrollFieldX[0];
            this.n総移動時間 = (int)(db移動時間 * 1000);
            this.n移動方向 = n移動方向;
            this.n移動距離px = n移動px;
        }


        #region[ private ]
        //-----------------
        //private CTexture txLane;
        //private CTexture txLaneB;
        //private CTexture tx枠線;
        //private CTexture tx判定枠;
        //private CTexture txゴーゴー;
        //private CTexture txゴーゴー炎;
        //private CTexture[] txArゴーゴー炎;
        //private CTexture[] txArアタックエフェクトLower_A;
        //private CTexture[] txArアタックエフェクトLower_B;
        //private CTexture[] txArアタックエフェクトLower_C;
        //private CTexture[] txArアタックエフェクトLower_D;

        //private CTexture[] txLaneFlush = new CTexture[3];

        //private CTexture[] tx普通譜面 = new CTexture[2];
        //private CTexture[] tx玄人譜面 = new CTexture[2];
        //private CTexture[] tx達人譜面 = new CTexture[2];

        //private CTextureAf txアタックエフェクトLower;

        protected STSTATUS[] st状態 = new STSTATUS[4];

        //private CTexture[] txゴーゴースプラッシュ;

        [StructLayout(LayoutKind.Sequential)]
        protected struct STSTATUS
        {
            public bool b使用中;
            public CCounter ct進行;
            public CCounter ct進行2;
            public E判定 judge;
            public int nIsBig;
            public int n透明度;
            public int nPlayer;
        }
        private CCounter ctゴーゴー;
        private CCounter ctゴーゴー炎;

     public bool b使用中;
        public CCounter ct進行;

        public E判定 judge;
        public int nIsBig;
        public int n透明度;
        public int nPlayer;
        private CCounter ctゴーゴースプラッシュ;
        private CCounter[] ct進行2 = new CCounter[3 * 4];

        protected STBRANCH[] stBranch = new STBRANCH[4];
        [StructLayout(LayoutKind.Sequential)]
        protected struct STBRANCH
        {
            public CCounter ct分岐アニメ進行;
            public int nBefore;
            public int nAfter;

            public long nフラッシュ制御タイマ;
            public int nBranchレイヤー透明度;
            public int nBranch文字透明度;
            public int nY座標;
            public int nY;
        }


        private int n総移動時間;
        private int n移動開始X;
        private int n移動開始Y;
        private int n移動開始時刻;
        private int n移動距離px;
        private int n移動方向;

        private int[] nDefaultJudgePos = new int[2];


        //-----------------
        #endregion
    }
}
