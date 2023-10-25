using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Net.Http.Headers;
using EldoradoBot.Responses;
using EldoradoBot.Requests;
using HtmlAgilityPack;
using System.Drawing;
using System.Windows;

namespace EldoradoBot
{
    public class Eldorado
    {
        public HttpClient? _client;

        private CookieContainer? _currentCookieContainer;

        private const string UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:102.0) Gecko/20100101 Firefox/102.0";

        public class AccOnEldorado
        {
            public string _itemId = "";
            public string _tradeEnvironmentValues = "";
            public string _offerAttributeIdValues = "";

            public AccOnEldorado(string itemId, string tradeEnvironmentValues, string offerAttributeIdValues)
            {
                _itemId = itemId;
                _tradeEnvironmentValues = tradeEnvironmentValues;
                _offerAttributeIdValues = offerAttributeIdValues;
            }
        }

        public bool Init(ConfigHandler configHandler)
        {
            try
            {
                //CookieContainer tmpContainer = new CookieContainer();
                //tmpContainer.Add(new Cookie("__Host-EldoradoRefreshToken", configHandler.EldoradoRefreshToken, "/", "www.eldorado.gg"));
                //tmpContainer.Add(new Cookie("rl_session", "RudderEncrypt%3AU2FsdGVkX19cvO4Zs0GHlbwwyHWR6rfqv8n81OEmk%2Bhm3My10MmnuWvXgZ871tk2p7NC%2BfuCnWqUyVGTNjOMawJJhfZw2Uwg%2B1a19Mdx783oh4jzJukl1mT1w6v0P1n86%2BWVgHUzedGgqXiQ7umJ4w%3D%3D", "/", "www.eldorado.gg"));
                //tmpContainer.Add(new Cookie("rl_user_id", "RudderEncrypt%3AU2FsdGVkX1%2BSTQReKxW59VJo%2BxY6ZQoONPwlqmD%2FkAI%2Bv3nGuAvdxg8aYe2emNYYWq4pLdNZxqQVvvZq6ttlXg%3D%3D", "/", "www.eldorado.gg"));
                //tmpContainer.Add(new Cookie("rl_trait", "RudderEncrypt%3AU2FsdGVkX1%2Bk%2BopuS7S%2BckZ642vubBWrwavpBE8sGmM%3D", "/", "www.eldorado.gg"));
                //tmpContainer.Add(new Cookie("rl_group_id", "RudderEncrypt%3AU2FsdGVkX1%2FCimqZWnmcRQUGflirNdNcDPs3XMbk7ic%3D", "/", "www.eldorado.gg"));
                //tmpContainer.Add(new Cookie("rl_group_trait", "RudderEncrypt%3AU2FsdGVkX1%2FHCFiXoN09cfLwd7xIXj6FyC%2BxzCrSCKI%3D", "/", "www.eldorado.gg"));
                //tmpContainer.Add(new Cookie("rl_anonymous_id", "RudderEncrypt%3AU2FsdGVkX1%2BRoXyrX6QbWk6VppGgVCcj0VxanbiXpwccWol075mrtf5tR8p5j0or%2Fr0CuE0qzi3FUXJ%2By5YGzg%3D%3D", "/", "www.eldorado.gg"));
                //tmpContainer.Add(new Cookie("rl_page_init_referrer", "RudderEncrypt%3AU2FsdGVkX18q3T4PnF5KAgfWHvvWO0wSlaojNopW2GY%3D", "/", "www.eldorado.gg"));
                //tmpContainer.Add(new Cookie("rl_page_init_referring_domain", "RudderEncrypt%3AU2FsdGVkX1%2FFtb2KbRU4V512nRarpeP6oVZx3wbcq2I%3D", "/", "www.eldorado.gg"));
                //tmpContainer.Add(new Cookie("_ga_S27PL70ZX1", "GS1.1.1697642703.94.1.1697645089.60.0.0", "/", "www.eldorado.gg"));
                //tmpContainer.Add(new Cookie("_ga_NMQG6CG3T7", "GS1.1.1697642703.203.1.1697645089.60.0.0", "/", "www.eldorado.gg"));
                //tmpContainer.Add(new Cookie("intercom-session-mipk5r3a", "SHZXYTZ5M3FzMloxcEtQaWVZN2F0VlZvQWMwYXhXUVoreGJjdmpQWVBIRmNGYmZjcDhHQVNYSVFZZVZkS2dVQy0taWdHUHJBaGlKOUVaQVUxa2d3RHpvUT09--098700e211c16a9bc42fd2654ba0c93634284058", "/", "www.eldorado.gg"));
                //_currentCookieContainer = tmpContainer;
                //_client = new HttpClient(new HttpClientHandler
                //{
                //    CookieContainer = _currentCookieContainer,
                //    AllowAutoRedirect = true,
                //    UseCookies = true,
                //    AutomaticDecompression = DecompressionMethods.All
                //}, false);

                _client = new HttpClient(new HttpClientHandler
                {
                    AllowAutoRedirect = true,
                    UseCookies = true,
                    AutomaticDecompression = DecompressionMethods.All
                }, false);
                //_client.DefaultRequestHeaders.Add("Referer", "https://www.eldorado.gg/account/auth-callback");
                //_client.DefaultRequestHeaders.Add("X-Correlation-ID", "194521a7-743b-4928-a34e-bccda9d2c36f");
                //_client.DefaultRequestHeaders.Add("X-GA-ClientId", "2057708875.1656090907");
                //_client.DefaultRequestHeaders.Add("x-client-build-time", "2023-10-19_16:24:12");
                //_client.DefaultRequestHeaders.Add("X-XSRF-TOKEN", "e02b39bb83514c8aadad3f1fda9051b790572909825a29e8b13b6c6ceecae6d5");
                _client.DefaultRequestHeaders.Add("Cookie", configHandler.Cookie);

                    //"eldoradogg_currencyPreference=USD; _ga=GA1.1.2057708875.1656090907; __zlcmid=1Adl1djsmoSAzKE; __Host-EldoradoRefreshToken=eyJjdHkiOiJKV1QiLCJlbmMiOiJBMjU2R0NNIiwiYWxnIjoiUlNBLU9BRVAifQ.q2_VRYPXtJdW9gDVCuWlt7m7Hk-5Qt6WapxB94uSU3uABLVQFCq6tXE8c4kp4v2D3OETD_60kehqyJKTr-R4jSmdOsq713m5Xvs7nw40LQtenG0FY--GA39Fy25iix6KlW118b1hK-oatEENO2wPYctUNH5oXckT04cReOH2oIO5xgBZ_PoIQPsyifGNNWV97zmd0ZoXKc_-l1jGG3XSIyR5YO6U9nt47Vdg7diGvUWT5ietiSANiHAccb-fmZ5gdH4sjTlqcj4EL6B8yEplHsUUq81NvytcyNacCiw3m1w5WYbm0Qtol3ibpGHIlpmbaMgnEztJ54wMpIWKqwgJ4A.nNFZKPgPN6o0KGlt.me0D6lOQuPTA3KPdjyjpNF21XEGcvv1oBRPtiJNBsmrk0kDalak2oeHfenPoyS8Eb_djXceDl8fYAqfY4GkrHpjigVYGtAljv0o9T83BgO5PiCpxANXt9KbZp8v8J1r8BKtXAouGE7aUs6YnsxNRKWmBRxtKYi5-0_Tq32Fs5-8T4z6qS3amX5oOM5eeobjYGekojAhmb0zITl7GggYtVpkXfl_u-Y1bZgwfK8aORWXkJSChO8Eb9rLL37Oi00LZg-exfezvkJAvEULtmwjXsW1GM4yo9ZMhs2W5y5vyoffqn7GvCH33Ve-_nasN5GBBotS9x-Pd2E8zfet_5F51oA3wDwZQNlCrBfqtCnU48fE85pJPDXkw319ZXrpz-Rk5kSA0zhGpG0LYpaH-PLNwgkzx6rQysDvgk6wsMAGJdRUVcFbW1pJ-xz4Qcb2Osx0ezfeNQV53Q3EQHk4QW5-FOQiPzJVp46eKhzz-jOEPyjz9QoZtDnf67WEN4bv4WMj2NwYE0U0K75AhSkRB6QtXVYwJLLYJx1azlI0iXj1dvSqShq7xKvIpg_REd-QkXmBwog2pzD9uwkfZYYffsk7JJDw_cJwSElJSJvEEWyUK4SzDE7F9wvvSevrEx_a8mEuJmcIhUtgrH08J4LEy5laA0V6CnKO_Dn3FhRPp7h0YgFCFaMhFu91PcMGvp3FMMCUkwf2H_dHWQwrI7--UcZ_3rvQP9BmvNkvhFALs8ZjJil9RGehu4mXJlX2hTK5yAz2LI6bny3VP0X7NP0stnVqOHs75TfHKeqotDwyYGUAmN8JaPkBsuhuJb1fV21R3TPO5c8x91Kh1NGCF4FdoL2njeB0DMYDBLxPzu61FhVDIfLoyKCpimQ2n28sERxA-u5CWOss_ezrMK-k5eM9uvS8Ey9mRf0-cyKDiXEJG5fmkZ2IBUJygPdHLgKeQrNRIf_aRE6w7yKWPPzXo4dnJw2JXlfbjkvOfCtiCxvs0dZihGpp28QLHeRT-2BlCTSfyE4CSufRGCy7kUmPPLbIRZe6Rxo3eI5I-Hhrm8H_hI-oPtDRcRlcFxe3L3M_DzNywC9eXrKQVNGMb03_C23fklVsHqUkjWOungjUW41r7wwdir4zvqpoGIoYgszrPAG-9A68NCxDDC9ouGm0JTuNGjrupZ2MV6m-Bv8klcqabZD3KYaxlS2y2IeUJwuOJjY7WXo3DsKUC9rlKeNfbdJvyEaT4rqFbBAU5HLxZpxXGAm4.7fL8ebx7Bb0HX_e7tNOQeg; _ga_S27PL70ZX1=GS1.1.1697825440.98.1.1697826722.41.0.0; cf_clearance=Qv4aEX5alx.3f2c0CUP31eV.p6lToDlF24wKSPOtSf8-1697823857-0-1-1a0585.217b732d.571b5a65-160.0.0; eldoradogg_locale=en-US; eldoradogg_localeSuggestion=%7B%22suggestedLocale%22%3A%22en-US%22%2C%22isResolved%22%3Atrue%2C%22previousIPCheckTimestamp%22%3A%222023-07-23T14%3A32%3A47.2781466Z%22%7D; smvr=eyJ2aXNpdHMiOjMwMiwidmlld3MiOjQwMTgsInRzIjoxNjg5NzY4NzY0MDU5LCJudW1iZXJPZlJlamVjdGlvbkJ1dHRvbkNsaWNrIjowLCJpc05ld1Nlc3Npb24iOmZhbHNlfQ==; smuuid=185f2e6c65c-f2b0e5b97333-b0a55b60-bf9d66f4-804ff42d-cebc2f9508cd; smclient=d50b2d09-cdcd-4e8b-a03e-272f8d26f5ee; smwp=true; rl_session=RudderEncrypt%3AU2FsdGVkX1%2BjFwygScpbUzA8BcRjpAuVvCj0rqqyZ3dkQGEufakWdEENgWkqn856VBxAbOxIxJH1lI3m8Xm0IB31i6VqCyR7cLicjxHdLLPHmgDTle4l9VHEOPprbQGwN42LAo2tCPyo9dRCslT8Xw%3D%3D; rl_user_id=RudderEncrypt%3AU2FsdGVkX181KjIZK%2FaodwwvEncVcv1zP1PZm8CxEhoDngMDKqXOKklX3KuWP5ZejdhUMX2QZY9TL3fsGHJcZw%3D%3D; rl_trait=RudderEncrypt%3AU2FsdGVkX19H%2BlA0PBD8YSsMwmpb4tzba%2BTeZxYGiUM%3D; rl_group_id=RudderEncrypt%3AU2FsdGVkX1%2FPbfVEaQg07C1gOGCFeQhx9dB531maeGg%3D; rl_group_trait=RudderEncrypt%3AU2FsdGVkX1%2B7VQ0ymQzm9EsjWGzG5hN8lg2Qn%2BRPMnY%3D; rl_anonymous_id=RudderEncrypt%3AU2FsdGVkX18uKLcNu8q%2BE6YQQs5d7OH%2Bz0spMYxgnfx2mWar7x4UmiwaCKpVZDIwvcHcxuhi3Lc82ofXxW36%2Bg%3D%3D; rl_page_init_referrer=RudderEncrypt%3AU2FsdGVkX18q3T4PnF5KAgfWHvvWO0wSlaojNopW2GY%3D; rl_page_init_referring_domain=RudderEncrypt%3AU2FsdGVkX1%2FFtb2KbRU4V512nRarpeP6oVZx3wbcq2I%3D; _ga_NMQG6CG3T7=GS1.1.1697825440.207.1.1697826722.41.0.0; eld-ab-test-autogenerateUsernames=0; eld-ab-test-seller-feedback-in-offer=1; eld-ab-test-homepage-poe=1; eld-ab-split-test-number-3=0; eld-ab-test-homepage-cs2=1; eld-ab-split-test-boosting-flow-updates=0; eld-ab-test-warrantyPopup=0; eld-ab-test-chat-no-purchase=1; cwv_fv=1; eld-ab-test-warranty-fees-duration=0; intercom-session-mipk5r3a=SHZXYTZ5M3FzMloxcEtQaWVZN2F0VlZvQWMwYXhXUVoreGJjdmpQWVBIRmNGYmZjcDhHQVNYSVFZZVZkS2dVQy0taWdHUHJBaGlKOUVaQVUxa2d3RHpvUT09--098700e211c16a9bc42fd2654ba0c93634284058; intercom-device-id-mipk5r3a=07c1dea4-9993-43f3-bbd4-52ed96e3578a; __Host-EldoradoIdToken=eyJraWQiOiJETTJSdklPTldaZThEd01ZNDNlbHZDTE9mbmZVNFozcWljOFQ4bmhTbmFBPSIsImFsZyI6IlJTMjU2In0.eyJhdF9oYXNoIjoiOEtOTU00N3F1anBxendUeS1FaXRKZyIsInN1YiI6IjI1MTJiY2I0LWU5NTktNGI3Ny1hOTNjLTlkMGU2NDc0ZTg0NiIsImVtYWlsX3ZlcmlmaWVkIjp0cnVlLCJpc3MiOiJodHRwczpcL1wvY29nbml0by1pZHAudXMtZWFzdC0yLmFtYXpvbmF3cy5jb21cL3VzLWVhc3QtMl9NbG56Q0ZnSGsiLCJjb2duaXRvOnVzZXJuYW1lIjoiMjUxMmJjYjQtZTk1OS00Yjc3LWE5M2MtOWQwZTY0NzRlODQ2IiwiY3VzdG9tOnVzZXJpZF9vdmVycmlkZSI6ImF1dGgwfDYwM2RlZGI1MDBjZjk1MDA3MGExZDAyZiIsInVzZXJJZCI6ImF1dGgwfDYwM2RlZGI1MDBjZjk1MDA3MGExZDAyZiIsIm9yaWdpbl9qdGkiOiJjYjkwZjVlNi00NGU1LTQwZmUtYWU0ZS00OTNjZDA0OThiOTUiLCJhdWQiOiIzYTRoYWw2amdsOGdmNWhubmpvMDZrMDVzNSIsInRva2VuX3VzZSI6ImlkIiwiYXV0aF90aW1lIjoxNjk3ODIzOTk3LCJleHAiOjE2OTc5MTA1OTgsImlhdCI6MTY5Nzg3NDU5OCwianRpIjoiZmRiYjJiNjEtMGExOS00YjdlLTgyZDEtNDMwMGZlMWJkZGVjIiwiZW1haWwiOiJqZWtzZXJhaGF1Y3Rpb25AZ21haWwuY29tIn0.aahrYuqjjEKNFH_I3xkNzanMJG24gsBF8tazaaOtRDlJAVOoA2IXOjX3lk1qZqXIR8EteSBA61jsuzg3vg7cKPXTICMkj374ojmjPSNjfffm7JOpJ9b4qD_rIXFsjRAK8OZ-23QzEyWtXuNBnm0ITfL9zFrPusqKbPhn05hcHm_ID3BMML0AMafzf-PWO2UwBoYn-tg9OA_-39UHtJAyN9nTUsQBi8kq0XiDJzxSWyb4b_z1Ko34hdOXar4Kj2l5TTgGc8LgKu5ua5dbjElKN_YvzOrAU6tI40RHpgBvHSCAPSXQHEdsuFaKheL9CNehuF9xRjY6mLXxt1D2v4FrKA; __Host-XSRF-TOKEN=e02b39bb83514c8aadad3f1fda9051b790572909825a29e8b13b6c6ceecae6d5; eldAbSplitTestTryout=undefined");
                    //"eldoradogg_currencyPreference=USD; _ga=GA1.1.2057708875.1656090907; __zlcmid=1Adl1djsmoSAzKE; __Host-EldoradoRefreshToken=eyJjdHkiOiJKV1QiLCJlbmMiOiJBMjU2R0NNIiwiYWxnIjoiUlNBLU9BRVAifQ.q2_VRYPXtJdW9gDVCuWlt7m7Hk-5Qt6WapxB94uSU3uABLVQFCq6tXE8c4kp4v2D3OETD_60kehqyJKTr-R4jSmdOsq713m5Xvs7nw40LQtenG0FY--GA39Fy25iix6KlW118b1hK-oatEENO2wPYctUNH5oXckT04cReOH2oIO5xgBZ_PoIQPsyifGNNWV97zmd0ZoXKc_-l1jGG3XSIyR5YO6U9nt47Vdg7diGvUWT5ietiSANiHAccb-fmZ5gdH4sjTlqcj4EL6B8yEplHsUUq81NvytcyNacCiw3m1w5WYbm0Qtol3ibpGHIlpmbaMgnEztJ54wMpIWKqwgJ4A.nNFZKPgPN6o0KGlt.me0D6lOQuPTA3KPdjyjpNF21XEGcvv1oBRPtiJNBsmrk0kDalak2oeHfenPoyS8Eb_djXceDl8fYAqfY4GkrHpjigVYGtAljv0o9T83BgO5PiCpxANXt9KbZp8v8J1r8BKtXAouGE7aUs6YnsxNRKWmBRxtKYi5-0_Tq32Fs5-8T4z6qS3amX5oOM5eeobjYGekojAhmb0zITl7GggYtVpkXfl_u-Y1bZgwfK8aORWXkJSChO8Eb9rLL37Oi00LZg-exfezvkJAvEULtmwjXsW1GM4yo9ZMhs2W5y5vyoffqn7GvCH33Ve-_nasN5GBBotS9x-Pd2E8zfet_5F51oA3wDwZQNlCrBfqtCnU48fE85pJPDXkw319ZXrpz-Rk5kSA0zhGpG0LYpaH-PLNwgkzx6rQysDvgk6wsMAGJdRUVcFbW1pJ-xz4Qcb2Osx0ezfeNQV53Q3EQHk4QW5-FOQiPzJVp46eKhzz-jOEPyjz9QoZtDnf67WEN4bv4WMj2NwYE0U0K75AhSkRB6QtXVYwJLLYJx1azlI0iXj1dvSqShq7xKvIpg_REd-QkXmBwog2pzD9uwkfZYYffsk7JJDw_cJwSElJSJvEEWyUK4SzDE7F9wvvSevrEx_a8mEuJmcIhUtgrH08J4LEy5laA0V6CnKO_Dn3FhRPp7h0YgFCFaMhFu91PcMGvp3FMMCUkwf2H_dHWQwrI7--UcZ_3rvQP9BmvNkvhFALs8ZjJil9RGehu4mXJlX2hTK5yAz2LI6bny3VP0X7NP0stnVqOHs75TfHKeqotDwyYGUAmN8JaPkBsuhuJb1fV21R3TPO5c8x91Kh1NGCF4FdoL2njeB0DMYDBLxPzu61FhVDIfLoyKCpimQ2n28sERxA-u5CWOss_ezrMK-k5eM9uvS8Ey9mRf0-cyKDiXEJG5fmkZ2IBUJygPdHLgKeQrNRIf_aRE6w7yKWPPzXo4dnJw2JXlfbjkvOfCtiCxvs0dZihGpp28QLHeRT-2BlCTSfyE4CSufRGCy7kUmPPLbIRZe6Rxo3eI5I-Hhrm8H_hI-oPtDRcRlcFxe3L3M_DzNywC9eXrKQVNGMb03_C23fklVsHqUkjWOungjUW41r7wwdir4zvqpoGIoYgszrPAG-9A68NCxDDC9ouGm0JTuNGjrupZ2MV6m-Bv8klcqabZD3KYaxlS2y2IeUJwuOJjY7WXo3DsKUC9rlKeNfbdJvyEaT4rqFbBAU5HLxZpxXGAm4.7fL8ebx7Bb0HX_e7tNOQeg; _ga_S27PL70ZX1=GS1.1.1697820328.97.0.1697820328.60.0.0; cf_clearance=Qv4aEX5alx.3f2c0CUP31eV.p6lToDlF24wKSPOtSf8-1697823857-0-1-1a0585.217b732d.571b5a65-160.0.0; eldoradogg_locale=en-US; eldoradogg_localeSuggestion=%7B%22suggestedLocale%22%3A%22en-US%22%2C%22isResolved%22%3Atrue%2C%22previousIPCheckTimestamp%22%3A%222023-07-23T14%3A32%3A47.2781466Z%22%7D; smvr=eyJ2aXNpdHMiOjMwMiwidmlld3MiOjQwMTgsInRzIjoxNjg5NzY4NzY0MDU5LCJudW1iZXJPZlJlamVjdGlvbkJ1dHRvbkNsaWNrIjowLCJpc05ld1Nlc3Npb24iOmZhbHNlfQ==; smuuid=185f2e6c65c-f2b0e5b97333-b0a55b60-bf9d66f4-804ff42d-cebc2f9508cd; smclient=d50b2d09-cdcd-4e8b-a03e-272f8d26f5ee; smwp=true; rl_session=RudderEncrypt%3AU2FsdGVkX183TWsxPkxIlBbkjkocla2FqAa4tXgLvTPk7mJmNw%2BlvgQrrcja2%2BzAkG5uxXyNldJ9isL71NV6Zyj8PNiPw4wRukXskfaSDT%2Bu2HDZZ%2BSGc9IsrhL2rppgaLYW1%2BLlDvtmgdvMRgf9Ag%3D%3D; rl_user_id=RudderEncrypt%3AU2FsdGVkX19SnU7DnYqvSem0qYEIdSpZh4NVkWjpkewxdIfCJNl%2FRO7k8hwqXxEYc9ondmEg92jv9yYesx%2BChA%3D%3D; rl_trait=RudderEncrypt%3AU2FsdGVkX19b5%2FiJzlaOoJSxFUvz3I0972U%2BFordXzA%3D; rl_group_id=RudderEncrypt%3AU2FsdGVkX1%2BQrHhik%2FclkaZVaKp8ZRRHqXg5tRm%2BA1M%3D; rl_group_trait=RudderEncrypt%3AU2FsdGVkX19aMumQoumzbwYGoHUlj0pIkDS6HpWSZQM%3D; rl_anonymous_id=RudderEncrypt%3AU2FsdGVkX1%2FTHm3bpZDA7i6vKJBf%2BNzngE1SChsUZUwocllw8MhCxGLJo6XHhV%2B1mSRarRi%2Fnn1aV5WmDJKp4A%3D%3D; rl_page_init_referrer=RudderEncrypt%3AU2FsdGVkX18q3T4PnF5KAgfWHvvWO0wSlaojNopW2GY%3D; rl_page_init_referring_domain=RudderEncrypt%3AU2FsdGVkX1%2FFtb2KbRU4V512nRarpeP6oVZx3wbcq2I%3D; _ga_NMQG6CG3T7=GS1.1.1697820327.206.0.1697820328.59.0.0; eld-ab-test-autogenerateUsernames=0; eld-ab-test-seller-feedback-in-offer=1; eld-ab-test-homepage-poe=1; eld-ab-split-test-number-3=0; eld-ab-test-homepage-cs2=1; eld-ab-split-test-boosting-flow-updates=0; eld-ab-test-warrantyPopup=0; eld-ab-test-chat-no-purchase=1; cwv_fv=1; eld-ab-test-warranty-fees-duration=0; intercom-session-mipk5r3a=SHZXYTZ5M3FzMloxcEtQaWVZN2F0VlZvQWMwYXhXUVoreGJjdmpQWVBIRmNGYmZjcDhHQVNYSVFZZVZkS2dVQy0taWdHUHJBaGlKOUVaQVUxa2d3RHpvUT09--098700e211c16a9bc42fd2654ba0c93634284058; intercom-device-id-mipk5r3a=07c1dea4-9993-43f3-bbd4-52ed96e3578a; __Host-XSRF-TOKEN=e02b39bb83514c8aadad3f1fda9051b790572909825a29e8b13b6c6ceecae6d5; eldAbSplitTestTryout=undefined; __Host-EldoradoIdToken=eyJraWQiOiJETTJSdklPTldaZThEd01ZNDNlbHZDTE9mbmZVNFozcWljOFQ4bmhTbmFBPSIsImFsZyI6IlJTMjU2In0.eyJhdF9oYXNoIjoiUG5vSkdkYTFLanlJdndFTHhqdTRpZyIsInN1YiI6IjI1MTJiY2I0LWU5NTktNGI3Ny1hOTNjLTlkMGU2NDc0ZTg0NiIsImVtYWlsX3ZlcmlmaWVkIjp0cnVlLCJpc3MiOiJodHRwczpcL1wvY29nbml0by1pZHAudXMtZWFzdC0yLmFtYXpvbmF3cy5jb21cL3VzLWVhc3QtMl9NbG56Q0ZnSGsiLCJjb2duaXRvOnVzZXJuYW1lIjoiMjUxMmJjYjQtZTk1OS00Yjc3LWE5M2MtOWQwZTY0NzRlODQ2IiwiY3VzdG9tOnVzZXJpZF9vdmVycmlkZSI6ImF1dGgwfDYwM2RlZGI1MDBjZjk1MDA3MGExZDAyZiIsInVzZXJJZCI6ImF1dGgwfDYwM2RlZGI1MDBjZjk1MDA3MGExZDAyZiIsIm9yaWdpbl9qdGkiOiJjYjkwZjVlNi00NGU1LTQwZmUtYWU0ZS00OTNjZDA0OThiOTUiLCJhdWQiOiIzYTRoYWw2amdsOGdmNWhubmpvMDZrMDVzNSIsInRva2VuX3VzZSI6ImlkIiwiYXV0aF90aW1lIjoxNjk3ODIzOTk3LCJleHAiOjE2OTc4NTk5OTcsImlhdCI6MTY5NzgyMzk5NywianRpIjoiYzRmNzE3ZTYtNmVlMi00OGU1LTlmN2EtOTA3YjdjYmQyM2YzIiwiZW1haWwiOiJqZWtzZXJhaGF1Y3Rpb25AZ21haWwuY29tIn0.L2EofrM4IgVXoTUR-wESC-YRoOVsJK1A1KjCfFQYy_mSI9_HzRmfSvllEk2NR0EWG8OxbBZu5SZ2TJf4BHVh5U7KTVVIywQ4RwYwCU53jSWFmV2I6yEjs_dhC6yMqOsmuFAS9DQaIAM95z7sgGNrM3ZN6dEPYqeTqE79P0C4lWep_oiT5QhFTi6rEHyjHWtlkMERJ9tQXN1LMCzwue53jdq-LWbKyicRUs1DwUQG7A72DZaEaaq1bLfpFloKDLPuksVREclAym65Z4qfewxdR_pmthSQAVRBdvPl2CHLbFEqW7SLIPVrjQpwmIMSDZv2e1x0zjQUkE7E47AjdhO6dA");
                if (_client is not null)
                {
                    AllOffersInfoRequest allOffersInfoRequest = new AllOffersInfoRequest(1, 40, "Account");
                    HttpResponseMessage? httpResponseMessage = _client.GetAsync(allOffersInfoRequest._Url).Result;
                    if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
                    {
                        Logger.AddLogRecord("Request Error, pls enter new cookie:", Logger.Status.WARN,true,false);
                        string newCookie = Logger.ReadFromConsole();
                        if (newCookie != null)
                        {
                            _client.DefaultRequestHeaders.Add("Cookie", newCookie);
                            AllOffersInfoRequest allOffersInfoRequestSecondTry = new AllOffersInfoRequest(1, 40, "Account");
                            HttpResponseMessage? httpResponseMessageSecondTry = _client.GetAsync(allOffersInfoRequestSecondTry._Url).Result;
                            if (httpResponseMessage.StatusCode != HttpStatusCode.OK)
                            {
                                Logger.AddLogRecord("Init ready", Logger.Status.OK);
                                return true;
                            }
                        else
                        {
                            Logger.AddLogRecord("Request Error, need help.", Logger.Status.BAD, true, false);
                            return false;
                        }
                        //if (!RefreshSession())
                        //{
                        //    return false;
                        //}
                    }
                }
                Logger.AddLogRecord("Init ready", Logger.Status.OK);
                return true;
            }
            catch (Exception ex)
            {
                Logger.AddLogRecord($"Init exeption: {ex}", Logger.Status.EXEPTION);
                return false;
            }
        }




        public void newPageRequest(ConfigHandler configHandler)
        {
            try
            {
                //CookieContainer tmpContainer = new CookieContainer();
                //tmpContainer.Add(new Cookie("__Host-EldoradoRefreshToken", configHandler.EldoradoRefreshToken, "/", "www.eldorado.gg"));
                //tmpContainer.Add(new Cookie("rl_session", "RudderEncrypt%3AU2FsdGVkX19cvO4Zs0GHlbwwyHWR6rfqv8n81OEmk%2Bhm3My10MmnuWvXgZ871tk2p7NC%2BfuCnWqUyVGTNjOMawJJhfZw2Uwg%2B1a19Mdx783oh4jzJukl1mT1w6v0P1n86%2BWVgHUzedGgqXiQ7umJ4w%3D%3D", "/", "www.eldorado.gg"));
                //tmpContainer.Add(new Cookie("rl_user_id", "RudderEncrypt%3AU2FsdGVkX1%2BSTQReKxW59VJo%2BxY6ZQoONPwlqmD%2FkAI%2Bv3nGuAvdxg8aYe2emNYYWq4pLdNZxqQVvvZq6ttlXg%3D%3D", "/", "www.eldorado.gg"));
                //tmpContainer.Add(new Cookie("rl_trait", "RudderEncrypt%3AU2FsdGVkX1%2Bk%2BopuS7S%2BckZ642vubBWrwavpBE8sGmM%3D", "/", "www.eldorado.gg"));
                //tmpContainer.Add(new Cookie("rl_group_id", "RudderEncrypt%3AU2FsdGVkX1%2FCimqZWnmcRQUGflirNdNcDPs3XMbk7ic%3D", "/", "www.eldorado.gg"));
                //tmpContainer.Add(new Cookie("rl_group_trait", "RudderEncrypt%3AU2FsdGVkX1%2FHCFiXoN09cfLwd7xIXj6FyC%2BxzCrSCKI%3D", "/", "www.eldorado.gg"));
                //tmpContainer.Add(new Cookie("rl_anonymous_id", "RudderEncrypt%3AU2FsdGVkX1%2BRoXyrX6QbWk6VppGgVCcj0VxanbiXpwccWol075mrtf5tR8p5j0or%2Fr0CuE0qzi3FUXJ%2By5YGzg%3D%3D", "/", "www.eldorado.gg"));
                //tmpContainer.Add(new Cookie("rl_page_init_referrer", "RudderEncrypt%3AU2FsdGVkX18q3T4PnF5KAgfWHvvWO0wSlaojNopW2GY%3D", "/", "www.eldorado.gg"));
                //tmpContainer.Add(new Cookie("rl_page_init_referring_domain", "RudderEncrypt%3AU2FsdGVkX1%2FFtb2KbRU4V512nRarpeP6oVZx3wbcq2I%3D", "/", "www.eldorado.gg"));
                //tmpContainer.Add(new Cookie("_ga_S27PL70ZX1", "GS1.1.1697642703.94.1.1697645089.60.0.0", "/", "www.eldorado.gg"));
                //tmpContainer.Add(new Cookie("_ga_NMQG6CG3T7", "GS1.1.1697642703.203.1.1697645089.60.0.0", "/", "www.eldorado.gg"));
                //tmpContainer.Add(new Cookie("intercom-session-mipk5r3a", "SHZXYTZ5M3FzMloxcEtQaWVZN2F0VlZvQWMwYXhXUVoreGJjdmpQWVBIRmNGYmZjcDhHQVNYSVFZZVZkS2dVQy0taWdHUHJBaGlKOUVaQVUxa2d3RHpvUT09--098700e211c16a9bc42fd2654ba0c93634284058", "/", "www.eldorado.gg"));
                //_currentCookieContainer = tmpContainer;
                _client = new HttpClient(new HttpClientHandler
                {

                    //CookieContainer = _currentCookieContainer,
                    AllowAutoRedirect = true,
                    UseCookies = true,
                    AutomaticDecompression = DecompressionMethods.All
                }, false);
                _client.DefaultRequestHeaders.Add("Referer", "https://www.eldorado.gg/account/auth-callback");
                _client.DefaultRequestHeaders.Add("X-Correlation-ID", "194521a7-743b-4928-a34e-bccda9d2c36f");
                _client.DefaultRequestHeaders.Add("X-GA-ClientId", "2057708875.1656090907");
                _client.DefaultRequestHeaders.Add("x-client-build-time", "2023-10-19_16:24:12");
                _client.DefaultRequestHeaders.Add("X-XSRF-TOKEN", "e02b39bb83514c8aadad3f1fda9051b790572909825a29e8b13b6c6ceecae6d5");
                _client.DefaultRequestHeaders.Add("Cookie", "eldoradogg_currencyPreference=USD; _ga=GA1.1.2057708875.1656090907; __zlcmid=1Adl1djsmoSAzKE; __Host-EldoradoRefreshToken=eyJjdHkiOiJKV1QiLCJlbmMiOiJBMjU2R0NNIiwiYWxnIjoiUlNBLU9BRVAifQ.q2_VRYPXtJdW9gDVCuWlt7m7Hk-5Qt6WapxB94uSU3uABLVQFCq6tXE8c4kp4v2D3OETD_60kehqyJKTr-R4jSmdOsq713m5Xvs7nw40LQtenG0FY--GA39Fy25iix6KlW118b1hK-oatEENO2wPYctUNH5oXckT04cReOH2oIO5xgBZ_PoIQPsyifGNNWV97zmd0ZoXKc_-l1jGG3XSIyR5YO6U9nt47Vdg7diGvUWT5ietiSANiHAccb-fmZ5gdH4sjTlqcj4EL6B8yEplHsUUq81NvytcyNacCiw3m1w5WYbm0Qtol3ibpGHIlpmbaMgnEztJ54wMpIWKqwgJ4A.nNFZKPgPN6o0KGlt.me0D6lOQuPTA3KPdjyjpNF21XEGcvv1oBRPtiJNBsmrk0kDalak2oeHfenPoyS8Eb_djXceDl8fYAqfY4GkrHpjigVYGtAljv0o9T83BgO5PiCpxANXt9KbZp8v8J1r8BKtXAouGE7aUs6YnsxNRKWmBRxtKYi5-0_Tq32Fs5-8T4z6qS3amX5oOM5eeobjYGekojAhmb0zITl7GggYtVpkXfl_u-Y1bZgwfK8aORWXkJSChO8Eb9rLL37Oi00LZg-exfezvkJAvEULtmwjXsW1GM4yo9ZMhs2W5y5vyoffqn7GvCH33Ve-_nasN5GBBotS9x-Pd2E8zfet_5F51oA3wDwZQNlCrBfqtCnU48fE85pJPDXkw319ZXrpz-Rk5kSA0zhGpG0LYpaH-PLNwgkzx6rQysDvgk6wsMAGJdRUVcFbW1pJ-xz4Qcb2Osx0ezfeNQV53Q3EQHk4QW5-FOQiPzJVp46eKhzz-jOEPyjz9QoZtDnf67WEN4bv4WMj2NwYE0U0K75AhSkRB6QtXVYwJLLYJx1azlI0iXj1dvSqShq7xKvIpg_REd-QkXmBwog2pzD9uwkfZYYffsk7JJDw_cJwSElJSJvEEWyUK4SzDE7F9wvvSevrEx_a8mEuJmcIhUtgrH08J4LEy5laA0V6CnKO_Dn3FhRPp7h0YgFCFaMhFu91PcMGvp3FMMCUkwf2H_dHWQwrI7--UcZ_3rvQP9BmvNkvhFALs8ZjJil9RGehu4mXJlX2hTK5yAz2LI6bny3VP0X7NP0stnVqOHs75TfHKeqotDwyYGUAmN8JaPkBsuhuJb1fV21R3TPO5c8x91Kh1NGCF4FdoL2njeB0DMYDBLxPzu61FhVDIfLoyKCpimQ2n28sERxA-u5CWOss_ezrMK-k5eM9uvS8Ey9mRf0-cyKDiXEJG5fmkZ2IBUJygPdHLgKeQrNRIf_aRE6w7yKWPPzXo4dnJw2JXlfbjkvOfCtiCxvs0dZihGpp28QLHeRT-2BlCTSfyE4CSufRGCy7kUmPPLbIRZe6Rxo3eI5I-Hhrm8H_hI-oPtDRcRlcFxe3L3M_DzNywC9eXrKQVNGMb03_C23fklVsHqUkjWOungjUW41r7wwdir4zvqpoGIoYgszrPAG-9A68NCxDDC9ouGm0JTuNGjrupZ2MV6m-Bv8klcqabZD3KYaxlS2y2IeUJwuOJjY7WXo3DsKUC9rlKeNfbdJvyEaT4rqFbBAU5HLxZpxXGAm4.7fL8ebx7Bb0HX_e7tNOQeg; _ga_S27PL70ZX1=GS1.1.1697820328.97.0.1697820328.60.0.0; cf_clearance=Qv4aEX5alx.3f2c0CUP31eV.p6lToDlF24wKSPOtSf8-1697823857-0-1-1a0585.217b732d.571b5a65-160.0.0; eldoradogg_locale=en-US; eldoradogg_localeSuggestion=%7B%22suggestedLocale%22%3A%22en-US%22%2C%22isResolved%22%3Atrue%2C%22previousIPCheckTimestamp%22%3A%222023-07-23T14%3A32%3A47.2781466Z%22%7D; smvr=eyJ2aXNpdHMiOjMwMiwidmlld3MiOjQwMTgsInRzIjoxNjg5NzY4NzY0MDU5LCJudW1iZXJPZlJlamVjdGlvbkJ1dHRvbkNsaWNrIjowLCJpc05ld1Nlc3Npb24iOmZhbHNlfQ==; smuuid=185f2e6c65c-f2b0e5b97333-b0a55b60-bf9d66f4-804ff42d-cebc2f9508cd; smclient=d50b2d09-cdcd-4e8b-a03e-272f8d26f5ee; smwp=true; rl_session=RudderEncrypt%3AU2FsdGVkX183TWsxPkxIlBbkjkocla2FqAa4tXgLvTPk7mJmNw%2BlvgQrrcja2%2BzAkG5uxXyNldJ9isL71NV6Zyj8PNiPw4wRukXskfaSDT%2Bu2HDZZ%2BSGc9IsrhL2rppgaLYW1%2BLlDvtmgdvMRgf9Ag%3D%3D; rl_user_id=RudderEncrypt%3AU2FsdGVkX19SnU7DnYqvSem0qYEIdSpZh4NVkWjpkewxdIfCJNl%2FRO7k8hwqXxEYc9ondmEg92jv9yYesx%2BChA%3D%3D; rl_trait=RudderEncrypt%3AU2FsdGVkX19b5%2FiJzlaOoJSxFUvz3I0972U%2BFordXzA%3D; rl_group_id=RudderEncrypt%3AU2FsdGVkX1%2BQrHhik%2FclkaZVaKp8ZRRHqXg5tRm%2BA1M%3D; rl_group_trait=RudderEncrypt%3AU2FsdGVkX19aMumQoumzbwYGoHUlj0pIkDS6HpWSZQM%3D; rl_anonymous_id=RudderEncrypt%3AU2FsdGVkX1%2FTHm3bpZDA7i6vKJBf%2BNzngE1SChsUZUwocllw8MhCxGLJo6XHhV%2B1mSRarRi%2Fnn1aV5WmDJKp4A%3D%3D; rl_page_init_referrer=RudderEncrypt%3AU2FsdGVkX18q3T4PnF5KAgfWHvvWO0wSlaojNopW2GY%3D; rl_page_init_referring_domain=RudderEncrypt%3AU2FsdGVkX1%2FFtb2KbRU4V512nRarpeP6oVZx3wbcq2I%3D; _ga_NMQG6CG3T7=GS1.1.1697820327.206.0.1697820328.59.0.0; eld-ab-test-autogenerateUsernames=0; eld-ab-test-seller-feedback-in-offer=1; eld-ab-test-homepage-poe=1; eld-ab-split-test-number-3=0; eld-ab-test-homepage-cs2=1; eld-ab-split-test-boosting-flow-updates=0; eld-ab-test-warrantyPopup=0; eld-ab-test-chat-no-purchase=1; cwv_fv=1; eld-ab-test-warranty-fees-duration=0; intercom-session-mipk5r3a=SHZXYTZ5M3FzMloxcEtQaWVZN2F0VlZvQWMwYXhXUVoreGJjdmpQWVBIRmNGYmZjcDhHQVNYSVFZZVZkS2dVQy0taWdHUHJBaGlKOUVaQVUxa2d3RHpvUT09--098700e211c16a9bc42fd2654ba0c93634284058; intercom-device-id-mipk5r3a=07c1dea4-9993-43f3-bbd4-52ed96e3578a; __Host-XSRF-TOKEN=e02b39bb83514c8aadad3f1fda9051b790572909825a29e8b13b6c6ceecae6d5; eldAbSplitTestTryout=undefined; __Host-EldoradoIdToken=eyJraWQiOiJETTJSdklPTldaZThEd01ZNDNlbHZDTE9mbmZVNFozcWljOFQ4bmhTbmFBPSIsImFsZyI6IlJTMjU2In0.eyJhdF9oYXNoIjoiUG5vSkdkYTFLanlJdndFTHhqdTRpZyIsInN1YiI6IjI1MTJiY2I0LWU5NTktNGI3Ny1hOTNjLTlkMGU2NDc0ZTg0NiIsImVtYWlsX3ZlcmlmaWVkIjp0cnVlLCJpc3MiOiJodHRwczpcL1wvY29nbml0by1pZHAudXMtZWFzdC0yLmFtYXpvbmF3cy5jb21cL3VzLWVhc3QtMl9NbG56Q0ZnSGsiLCJjb2duaXRvOnVzZXJuYW1lIjoiMjUxMmJjYjQtZTk1OS00Yjc3LWE5M2MtOWQwZTY0NzRlODQ2IiwiY3VzdG9tOnVzZXJpZF9vdmVycmlkZSI6ImF1dGgwfDYwM2RlZGI1MDBjZjk1MDA3MGExZDAyZiIsInVzZXJJZCI6ImF1dGgwfDYwM2RlZGI1MDBjZjk1MDA3MGExZDAyZiIsIm9yaWdpbl9qdGkiOiJjYjkwZjVlNi00NGU1LTQwZmUtYWU0ZS00OTNjZDA0OThiOTUiLCJhdWQiOiIzYTRoYWw2amdsOGdmNWhubmpvMDZrMDVzNSIsInRva2VuX3VzZSI6ImlkIiwiYXV0aF90aW1lIjoxNjk3ODIzOTk3LCJleHAiOjE2OTc4NTk5OTcsImlhdCI6MTY5NzgyMzk5NywianRpIjoiYzRmNzE3ZTYtNmVlMi00OGU1LTlmN2EtOTA3YjdjYmQyM2YzIiwiZW1haWwiOiJqZWtzZXJhaGF1Y3Rpb25AZ21haWwuY29tIn0.L2EofrM4IgVXoTUR-wESC-YRoOVsJK1A1KjCfFQYy_mSI9_HzRmfSvllEk2NR0EWG8OxbBZu5SZ2TJf4BHVh5U7KTVVIywQ4RwYwCU53jSWFmV2I6yEjs_dhC6yMqOsmuFAS9DQaIAM95z7sgGNrM3ZN6dEPYqeTqE79P0C4lWep_oiT5QhFTi6rEHyjHWtlkMERJ9tQXN1LMCzwue53jdq-LWbKyicRUs1DwUQG7A72DZaEaaq1bLfpFloKDLPuksVREclAym65Z4qfewxdR_pmthSQAVRBdvPl2CHLbFEqW7SLIPVrjQpwmIMSDZv2e1x0zjQUkE7E47AjdhO6dA");

                if (_client is not null)
                {
                    newRequestTest newRequestTest = new newRequestTest();
                    HttpResponseMessage? httpResponseMessage = _client.GetAsync(newRequestTest._Url).Result;
                    if (httpResponseMessage.StatusCode == HttpStatusCode.OK && httpResponseMessage.Content != null)
                    {
                        var jsonString = httpResponseMessage.Content.ReadAsStringAsync().Result;
                        if (jsonString is not null)
                        {
                            GetMyBalance.Root? balanceInfo = System.Text.Json.JsonSerializer.Deserialize<GetMyBalance.Root>(jsonString);
                            if (balanceInfo is not null)
                            {
                                Logger.AddLogRecord("Got activities", Logger.Status.OK);
                                var balance = balanceInfo.userPaymentPrivateDTO.balanceInUSD.amount.ToString();
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.AddLogRecord($"Init exeption: {ex}", Logger.Status.EXEPTION);
            }
        }



        // works with new cookies
        public string? GetMyBalance()
        {
            try
            {
                if (_client is not null)
                {
                    newRequestTest newRequestTest = new newRequestTest();
                    HttpResponseMessage? httpResponseMessage = _client.GetAsync(newRequestTest._Url).Result;
                    if (httpResponseMessage.StatusCode == HttpStatusCode.OK && httpResponseMessage.Content != null)
                    {
                        var jsonString = httpResponseMessage.Content.ReadAsStringAsync().Result;
                        if (jsonString is not null)
                        {
                            GetMyBalance.Root? balanceInfo = System.Text.Json.JsonSerializer.Deserialize<GetMyBalance.Root>(jsonString);
                            if (balanceInfo is not null)
                            {
                                Logger.AddLogRecord("Got my balance", Logger.Status.OK);
                                return balanceInfo.userPaymentPrivateDTO.balanceInUSD.amount.ToString();
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Logger.AddLogRecord($"GetMyBalance exeption: {ex}", Logger.Status.EXEPTION);
                return null;
            }
        }

        private HtmlAgilityPack.HtmlDocument? GetHtml(string url)
        {
            try
            {
                if (_client is not null)
                {
                    var response = _client.GetAsync(url).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var html = response.Content.ReadAsStringAsync().Result;
                        if (!string.IsNullOrEmpty(html))
                        {
                            HtmlAgilityPack.HtmlDocument htmldoc = new HtmlAgilityPack.HtmlDocument();
                            htmldoc.LoadHtml(html);
                            return htmldoc;
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Logger.AddLogRecord($"Failed to get html: {ex}", Logger.Status.EXEPTION);
                return null;
            }
        }

        public void StartMessageAndDisputsChecking(string link, bool refreshTokenIsGood)
        {
            Thread eldoradoDataRenewingthread = new Thread(() => { MessageChecking(link, refreshTokenIsGood); });
            eldoradoDataRenewingthread.Start();
        }

        private void MessageChecking(string link, bool refreshTokenIsValid)
        {
            try
            {
                if ((link is not null) && (refreshTokenIsValid is true))
                {
                    Dictionary<string, string>? messageHistory = new Dictionary<string, string>();
                    while (refreshTokenIsValid)
                    {
                        //Check for messages
                        HtmlAgilityPack.HtmlDocument? htmlDoc = GetHtml(link);
                        if (htmlDoc is not null)
                        {
                            HtmlNodeCollection? chats = htmlDoc.DocumentNode.SelectNodes(".//a[@class='ConversationListItem__conversation-link ConversationListItem__unread']"); ;
                            var activeChat = htmlDoc.DocumentNode.SelectSingleNode(".//a[@class='ConversationListItem__conversation-link ConversationListItem__active ConversationListItem__unread']");
                            if (activeChat is not null && chats is not null)
                            {
                                chats?.Add(activeChat);
                            }
                            if (chats is not null)
                            {
                                foreach (var chat in chats)
                                {
                                    string messageText = chat.SelectSingleNode(".//div[contains(@class,'ConversationListItem__message')]").SelectSingleNode(".//span[contains(@class,'Emojilinkistrippify')]").InnerText;
                                    string buyerName = chat.GetAttributeValue("title", "");
                                    if (!messageText.Contains("left the chat.") && !messageText.Contains("If you received goods or services"))
                                    {
                                        if (messageHistory.ContainsKey(buyerName) == false || messageHistory[buyerName] != messageText)
                                        {
                                            Logger.AddLogRecord($" ⚠️ {buyerName} => {messageText}", Logger.Status.OK, true, false);
                                            messageHistory[buyerName] = messageText;
                                        }
                                    }
                                }
                            }
                        }
                        if (messageHistory.Count > 20)
                        {
                            messageHistory.Clear();
                        }
                        Thread.Sleep(5000);
                    }
                }
                else
                {
                    Logger.AddLogRecord($"Wrong token or link cannot check for unread messages", Logger.Status.BAD);
                }
            }
            catch (Exception ex)
            {
                Logger.AddLogRecord($"Error while checking unread messages: {ex}", Logger.Status.EXEPTION);
            }
        }

        public List<List<string>>? ReadSpecificAccsFromLocalFile(Utils.GameAccOffer offer)
        {
            try
            {
                List<List<string>> AccsBase = new List<List<string>>() { };
                if (offer._FileToGetAccFromName is not null)
                {
                    var accs = Utils.ReadAllAccs(offer._FileToGetAccFromName);
                    foreach (var acc in accs)
                    {
                        var tempRes = acc.Split($"{offer._DelimiterForGetAccFile}").ToList();
                        if (!tempRes[tempRes.Count - 1].Contains("#"))
                        {
                            tempRes.Add("--------");
                            tempRes.Add($"#{Utils.GenerateToken()}");
                        }
                        AccsBase.Add(tempRes);
                    }
                }
                return AccsBase;
            }
            catch (Exception ex)
            {
                Logger.AddLogRecord($"Exeption while read single file for accs: {ex}", Logger.Status.EXEPTION);
                return null;
            }
        }

        public List<List<List<string>>>? ReadAllAccsFromLocalFile(List<Utils.GameAccOffer> Offers)
        {
            try
            {
                List<List<List<string>>> AllAccsBase = new List<List<List<string>>>() { };
                foreach (Utils.GameAccOffer offer in Offers)
                {
                    if (offer._FileToGetAccFromName is not null)
                    {
                        var accs = Utils.ReadAllAccs(offer._FileToGetAccFromName);
                        List<List<string>> acctmp = new List<List<string>>() { };
                        foreach (var acc in accs)
                        {
                            var tempRes = acc.Split($"{offer._DelimiterForGetAccFile}").ToList();
                            if (!tempRes[tempRes.Count - 1].Contains("#"))
                            {
                                tempRes.Add("--------");
                                tempRes.Add($"#{Utils.GenerateToken()}");
                            }
                            acctmp.Add(tempRes);
                        }
                        AllAccsBase.Add(acctmp);
                    }
                }
                Logger.AddLogRecord($"Read accs for {AllAccsBase.Count} offer types", Logger.Status.OK);
                return AllAccsBase;
            }
            catch (Exception ex)
            {
                Logger.AddLogRecord($"Exeption while read all accs files: {ex}", Logger.Status.EXEPTION);
                return null;
            }
        }

        public bool RefreshSession()
        {
            try
            {
                if (_client is not null)
                {
                    _client.DefaultRequestHeaders.UserAgent.TryParseAdd(UserAgent);
                    RefreshSessionRequest refreshSessionRequest = new RefreshSessionRequest();
                    HttpResponseMessage? httpResponseMessage = _client.PostAsync(refreshSessionRequest._Url, null).Result;
                    if (httpResponseMessage.StatusCode == HttpStatusCode.OK && httpResponseMessage.Content != null)
                    {
                        HttpHeaders headers = httpResponseMessage.Headers;
                        string newCookie = "";
                        if (headers.TryGetValues("set-cookie", out IEnumerable<string>? values))
                        {
                            newCookie = values.First();
                        }
                        Regex regex = new Regex(@"\=(.*?)\;");
                        string res = regex.Match(newCookie).Groups[1].ToString();
                        if (_currentCookieContainer is not null)
                        {
                            _currentCookieContainer.Add(new Cookie("__Host-EldoradoIdToken", res, "/", "www.eldorado.gg"));
                            Logger.AddLogRecord("Session refreshed", Logger.Status.OK);
                            return true;
                        }
                    }
                }
                Logger.AddLogRecord("Failed refreshing", Logger.Status.BAD);
                return false;
            }
            catch (Exception ex)
            {
                Logger.AddLogRecord($"Refreshing exeption: {ex}", Logger.Status.EXEPTION);
                return false;
            }
        }

        public bool CreateNewOrder(string login, string password)
        {
            try
            {
                if (_client is not null)
                {
                    string json = File.ReadAllText($"{Environment.CurrentDirectory}\\Offer.json");
                    string res = json.Replace("Login : xxxxxxxxx", $"Login : {login}").Replace("Password : xxxxxxxxx", $"Password : {password}");
                    var httpContent = new StringContent(res, Encoding.UTF8, "application/json");
                    var httpResponse = _client.PostAsync(NewOffer._Url, httpContent).Result;
                    if (httpResponse.StatusCode == HttpStatusCode.Created && httpResponse.Content != null)
                    {
                        Logger.AddLogRecord("New offer created", Logger.Status.OK);
                        return true;
                    }
                }
                Logger.AddLogRecord("Failed creating new order", Logger.Status.BAD);
                return false;
            }
            catch (Exception ex)
            {
                Logger.AddLogRecord($"Creating new order exeption: {ex}", Logger.Status.EXEPTION);
                return false;
            }
        }

        // works with new cookies
        public int GetActivities()
        {
            try
            {
                if (_client is not null)
                {
                    GetActivitiesRequest ActivitiesRequest = new GetActivitiesRequest();
                    HttpResponseMessage? httpResponseMessage = _client.GetAsync(ActivitiesRequest._Url).Result;
                    if (httpResponseMessage.StatusCode == HttpStatusCode.OK && httpResponseMessage.Content != null)
                    {
                        var jsonString = httpResponseMessage.Content.ReadAsStringAsync().Result;
                        if (jsonString is not null)
                        {
                            GetActivitiesResponse.Root? activitiesInfo = System.Text.Json.JsonSerializer.Deserialize<GetActivitiesResponse.Root>(jsonString);
                            if (activitiesInfo is not null)
                            {
                                Logger.AddLogRecord("Got activities", Logger.Status.OK);
                                return activitiesInfo.disputedOrderCount;
                            }
                        }
                    }
                }
                Logger.AddLogRecord("Failed getting activities", Logger.Status.BAD);
                return -1;
            }
            catch (Exception ex)
            {
                Logger.AddLogRecord($"Get activities exeption: {ex}", Logger.Status.EXEPTION);
                return -1;
            }
        }

        public bool CreateNewOfferFromFile(Utils.GameAccOffer offerInfo, List<string> acc)
        {
            try
            {
                if (_client is not null)
                {
                    string json = File.ReadAllText($"{Environment.CurrentDirectory}\\JsonSamples\\{offerInfo._OfferSampleJsonFileName}.json");
                    json = json.Replace("(#)", acc[acc.Count - 1]);
                    if (offerInfo?._AccInfoPositions is not null)
                    {
                        foreach (var spot in offerInfo._AccInfoPositions)
                        {
                            json = json.Replace(spot[1], acc[Convert.ToInt32(spot[0])]);

                        }
                        var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                        var httpResponse = _client.PostAsync(NewOffer._Url, httpContent).Result;
                        if (httpResponse.StatusCode == HttpStatusCode.Created && httpResponse.Content != null)
                        {
                            Logger.AddLogRecord($"New offer {offerInfo._OfferName} => {acc[acc.Count - 1]} created", Logger.Status.OK);
                            return true;
                        }
                        else
                        {
                            Logger.AddLogRecord($"Failed creating new order {httpResponse.StatusCode}|{httpResponse.RequestMessage}|{httpResponse.ReasonPhrase}", Logger.Status.BAD);
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                Logger.AddLogRecord($"Creating new order exeption: {ex}", Logger.Status.EXEPTION);
                return false;
            }
        }

        // works with new cookies
        public bool DeleteAccOffer(string itemId)
        {
            if (_client != null)
            {
                DeleteAccFromEldoradoRequest deleteAccFromEldoradoRequest = new DeleteAccFromEldoradoRequest(itemId);
                HttpResponseMessage? httpResponseMessage = _client.DeleteAsync(deleteAccFromEldoradoRequest._Url).Result;
                if (httpResponseMessage.StatusCode == HttpStatusCode.NoContent)
                {
                    Logger.AddLogRecord($"Acc {itemId} was deleted", Logger.Status.OK);
                    return true;
                }
            }
            return false;
        }

        public bool PauseGameOffers(AccOnEldorado itemId)
        {
            if (_client != null)
            {
                Regex regex = new Regex(@"\d-\d");
                var res = regex.Match(itemId._offerAttributeIdValues).ToString();
                PauseAllOffersRequest pauseOffersRequest = new PauseAllOffersRequest(itemId._itemId, "Account", res, itemId._tradeEnvironmentValues);
                HttpResponseMessage? httpResponseMessage = _client.PutAsync(pauseOffersRequest._Url, null).Result;
                if (httpResponseMessage.StatusCode == HttpStatusCode.OK)
                {
                    Logger.AddLogRecord($"All {itemId._itemId}|{itemId._offerAttributeIdValues}|{itemId._tradeEnvironmentValues} was paused", Logger.Status.OK);
                    return true;
                }
            }
            return false;
        }

        public int? ResumeGameOffers(AccOnEldorado itemId)
        {
            if (_client != null)
            {
                Regex regex = new Regex(@"\d-\d");
                var res = regex.Match(itemId._offerAttributeIdValues).ToString();
                ResumeAllOffersRequest pauseOffersRequest = new ResumeAllOffersRequest(itemId._itemId, "Account", res, itemId._tradeEnvironmentValues);
                HttpResponseMessage? httpResponseMessage = _client.PutAsync(pauseOffersRequest._Url, null).Result;
                if (httpResponseMessage.StatusCode == HttpStatusCode.OK && httpResponseMessage.Content != null)
                {
                    var jsonString = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    if (jsonString is not null)
                    {
                        ResumeAccsResponse.Root? info = System.Text.Json.JsonSerializer.Deserialize<ResumeAccsResponse.Root>(jsonString);
                        if (info is not null && info.totalOffersToResumeLimitReached == false)
                        {
                            return info.offersInGivenFilterCount;
                        }
                    }
                }
            }
            return null;
        }

        // works with new cookies
        public List<AllAccsInfo.Result>? GetAllOffersInfoFromEldorado()
        {
            try
            {
                List<AllAccsInfo.Result> res = new List<AllAccsInfo.Result>();
                if (_client is not null)
                {
                    AllOffersInfoRequest allOffersInfoRequest = new AllOffersInfoRequest(1, 40, "Account");
                    HttpResponseMessage? httpResponseMessage = _client.GetAsync(allOffersInfoRequest._Url).Result;
                    if (httpResponseMessage.StatusCode == HttpStatusCode.OK && httpResponseMessage.Content != null)
                    {
                        var jsonString = httpResponseMessage.Content.ReadAsStringAsync().Result;
                        if (jsonString is not null)
                        {
                            AllAccsInfo.Root? allAccsInfo = System.Text.Json.JsonSerializer.Deserialize<AllAccsInfo.Root>(jsonString);
                            if (allAccsInfo is not null && allAccsInfo.recordCount is not null)
                            {
                                for (int i = 1; i <= allAccsInfo.totalPages; i++)
                                {
                                    AllOffersInfoRequest allOffersInfoSecondRequest = new AllOffersInfoRequest(i, 40, "Account");
                                    HttpResponseMessage? httpResponseSecondMessage = _client.GetAsync(allOffersInfoSecondRequest._Url).Result;
                                    if (httpResponseMessage.StatusCode == HttpStatusCode.OK && httpResponseSecondMessage.Content != null)
                                    {
                                        var secondJsonString = httpResponseSecondMessage.Content.ReadAsStringAsync().Result;
                                        if (secondJsonString is not null)
                                        {
                                            AllAccsInfo.Root? secondAllAccsInfo = System.Text.Json.JsonSerializer.Deserialize<AllAccsInfo.Root>(secondJsonString);
                                            if (secondAllAccsInfo is not null && secondAllAccsInfo.results is not null)
                                            {
                                                foreach (var result in secondAllAccsInfo.results)
                                                {
                                                    res.Add(result);
                                                }
                                            }

                                        }
                                    }
                                    Thread.Sleep(500);
                                }
                                if (res.Count == allAccsInfo.recordCount)
                                {
                                    Logger.AddLogRecord("Got all accs info", Logger.Status.OK);
                                    return res;
                                }
                            }
                        }
                    }
                    else
                    {
                        Logger.AddLogRecord("failed", Logger.Status.BAD);
                    }
                }
                Logger.AddLogRecord("Failed getting all accs info", Logger.Status.BAD);
                return null;
            }
            catch (Exception ex)
            {
                Logger.AddLogRecord($"Getting all accs info exeption: {ex}", Logger.Status.EXEPTION);
                return null;
            }
        }

        //public List<List<string>> GetAllAccsFromEldorado(List<AllAccsInfo.Result> accsInfo)
        //{
        //    //Getting all accs from eldorado
        //    List<List<string>> allAccsFromEldorado = new List<List<string>>() { };
        //    List<List<string>> closedAccs = new List<List<string>>() { };
        //    List<List<string>> activeAccs = new List<List<string>>() { };
        //    List<List<string>> pausedAccs = new List<List<string>>() { };
        //    foreach (var acc in accsInfo)
        //    {
        //        Regex regex = new Regex(@"[#][a-zA-Z\d]{20}");
        //        if (acc.description is not null)
        //        {
        //            List<string> tmp = new List<string> { acc?.offerState, regex.Match(acc.description.ToString()).ToString(), acc?.id, acc?.pricePerUnit?.amount?.ToString(), acc?.pricePerUnit?.currency?.ToString(), acc?.offerTitle?.ToString(), acc.itemId };
        //            if (acc?.tradeEnvironmentValues.Count == 0)
        //            {
        //                tmp.Add(null);
        //            }
        //            else
        //            {
        //                foreach (var value in acc?.tradeEnvironmentValues)
        //                {
        //                    tmp.Add(value.id?.ToString());
        //                }
        //            }
        //            allAccsFromEldorado.Add(tmp);
        //            if (acc.offerState == "Closed")
        //            {
        //                closedAccs.Add(tmp);
        //            }
        //            if (acc.offerState == "Active")
        //            {
        //                activeAccs.Add(tmp);
        //            }
        //            if (acc.offerState == "Paused")
        //            {
        //                pausedAccs.Add(tmp);
        //            }
        //        }
        //    }
        //    Logger.AddLogRecord($"Eldorado => Total: {allAccsFromEldorado.Count} Active: {activeAccs.Count} Paused: {pausedAccs.Count} Closed: {closedAccs.Count} ", Logger.Status.OK);
        //    return allAccsFromEldorado;
        //}

        //#region Base functions for any window

        ///// <summary>
        ///// Parse text from image
        ///// </summary>
        ///// <param name="image"></param>
        ///// <returns></returns>
        //        public static string ParseBitmap(Bitmap image)
        //        {
        //            var Ocr = new IronTesseract();
        //            using (var Input = new OcrInput(image))
        //            {
        //                Input.Contrast();
        //                Input.Invert();
        //                var Result = Ocr.Read(Input);
        //                return Result.Text;
        //            }
        //        }

        //        /// <summary>
        //        /// Crop bitmap image to certain size 
        //        /// </summary>
        //        /// <param name="bitmap"></param>
        //        /// <param name="x"></param>
        //        /// <param name="y"></param>
        //        /// <param name="width"></param>
        //        /// <param name="height"></param>
        //        /// <returns></returns>
        //        public static Bitmap GetCroppedBitmap(Bitmap bitmap, int x, int y, int width, int height)
        //        {
        //            Bitmap retBitmap = null;
        //            using (var currentTile = new Bitmap(width, height))
        //            {
        //                using (var currentTileGraphics = Graphics.FromImage(currentTile))
        //                {
        //                    currentTileGraphics.Clear(System.Drawing.Color.Black);
        //                    var absentRectangleArea = new System.Drawing.Rectangle(x, y, width, height);
        //                    currentTileGraphics.DrawImage(bitmap, 0, 0, absentRectangleArea, GraphicsUnit.Pixel);
        //                }
        //                retBitmap = new Bitmap(currentTile);
        //            }
        //            return retBitmap;
        //        }

        //        /// <summary>
        //        /// Returns window rectangle or empty rectangle if there no window
        //        /// </summary>
        //        /// <param name="winToFindName"></param>
        //        /// <returns></returns>
        //        public static Rectangle GetWindowRect(string winToFindName, string windowToFindClass, bool needed)
        //        {
        //            lock (scrLock)
        //            {
        //                if (!IsTheWindowsExist(windowToFindClass))
        //                {
        //                    return Rectangle.Empty;
        //                }
        //                if (needed && (AutoItX.WinGetTitle("[ACTIVE]") != winToFindName))
        //                {
        //                    AutoItX.WinActivate(windowToFindClass);
        //                    AutoItX.WinGetTitle();
        //                }
        //                return AutoItX.WinGetPos(windowToFindClass);
        //            }
        //        }

        //        /// <summary>
        //        /// Check is there windows exists 
        //        /// </summary>
        //        /// <returns></returns>
        //        public static bool IsTheWindowsExist(string windowToFindClass)
        //        {
        //            lock (scrLock)
        //            {
        //                return AutoItX.WinExists(windowToFindClass) == 1;
        //            }
        //        }

        //        /// <summary>
        //        /// Return certain window screenshot as bitmap or null 
        //        /// </summary>
        //        /// <param name="windowToActivateName"></param>
        //        /// <param name="windowToFindClass"></param>
        //        /// <param name="screenshotLock"></param>
        //        /// <returns></returns>
        //        public static Bitmap GetWinScreenshot(string windowToActivateName, string windowToFindClass)
        //        {
        //            lock (scrLock)
        //            {
        //                Rectangle currWinRect = GetWindowRect(windowToActivateName, windowToFindClass, true);
        //                if (currWinRect == Rectangle.Empty)
        //                {
        //                    return null;
        //                }
        //                Bitmap bitmap = new Bitmap(currWinRect.Width, currWinRect.Height);
        //                using (Graphics graphics = Graphics.FromImage(bitmap))
        //                {
        //                    graphics.CopyFromScreen(new System.Drawing.Point(currWinRect.Left, currWinRect.Top), System.Drawing.Point.Empty, currWinRect.Size);
        //                }
        //                return bitmap;
        //            }
        //        }

        //        [DllImport("user32.dll", SetLastError = true)]
        //        [return: MarshalAs(UnmanagedType.Bool)]
        //        static extern bool PrintWindow(IntPtr hwnd, IntPtr hDC, uint nFlags);

        //        /// <summary>
        //        /// Return certain window screenshot even if it is not active as bitmap or null
        //        /// </summary>
        //        /// <param name="windowToActivateName"></param>
        //        /// <param name="windowToFindClass"></param>
        //        /// <param name="screenshotLock"></param>
        //        /// <returns></returns>
        //        /// 
        //        public static Bitmap GetWinScreenshotNotActive(string windowToActivateName, string windowToFindClass)
        //        {
        //            lock (scrLock)
        //            {
        //                Rectangle currWinRect = GetWindowRect(windowToActivateName, windowToFindClass, false);
        //                if (currWinRect == Rectangle.Empty)
        //                {
        //                    return null;
        //                }
        //                Bitmap B = new Bitmap(currWinRect.Width, currWinRect.Height);
        //                using (Graphics graphics = Graphics.FromImage(B))
        //                {
        //                    Bitmap bmp = new Bitmap(currWinRect.Size.Width, currWinRect.Size.Height, graphics);
        //                    Graphics memoryGraphics = Graphics.FromImage(bmp);
        //                    IntPtr dc = memoryGraphics.GetHdc();
        //                    var handle = AutoItX.WinGetHandle(windowToFindClass);
        //                    bool success = PrintWindow(handle, dc, 0);
        //                    memoryGraphics.ReleaseHdc(dc);
        //                    return bmp;
        //                }
        //            }
        //        }

        //        /// <summary>
        //        /// Gets whole screen screenshot
        //        /// </summary>
        //        /// <returns></returns>
        //        public static Bitmap GetScreenShot()
        //        {
        //            Rectangle bounds = new Rectangle(0, 0, (int)SystemParameters.VirtualScreenWidth, (int)SystemParameters.VirtualScreenHeight);
        //            Bitmap Screenshot = new Bitmap(bounds.Width, bounds.Height);
        //            using (Graphics graphics = Graphics.FromImage(Screenshot))
        //            {
        //                graphics.CopyFromScreen(new System.Drawing.Point(bounds.Left, bounds.Top), System.Drawing.Point.Empty, bounds.Size);
        //            }
        //            return Screenshot;
        //        }

        //        /// <summary>Finds a matching image on the screen.</summary>
        //        ///     ''' <param name="bmpMatch">The image to find on the screen.</param>
        //        ///     ''' <param name="ExactMatch">True finds an exact match (slowerer on large images). False finds a close match (faster on large images).</param>
        //        ///     ''' <param name="bmpWhereFind">Picture where to find subimage.</param>
        //        ///     ''' <returns>Returns a Rectangle of the found image in sceen coordinates.</returns>
        //        public static Rectangle FindImageOnScreen(Bitmap bmpMatch, Bitmap bmpWhereFind, bool ExactMatch)
        //        {
        //            BitmapData ImgBmd = bmpMatch.LockBits(new Rectangle(0, 0, bmpMatch.Width, bmpMatch.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
        //            BitmapData ScreenBmd = bmpWhereFind.LockBits(new Rectangle(0, 0, bmpWhereFind.Width, bmpWhereFind.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

        //            byte[] ImgByts = new byte[(Math.Abs(ImgBmd.Stride) * bmpMatch.Height) - 1 + 1];
        //            byte[] ScreenByts = new byte[(Math.Abs(ScreenBmd.Stride) * bmpWhereFind.Height) - 1 + 1];

        //            Marshal.Copy(ImgBmd.Scan0, ImgByts, 0, ImgByts.Length);
        //            Marshal.Copy(ScreenBmd.Scan0, ScreenByts, 0, ScreenByts.Length);

        //            bool FoundMatch = false;
        //            Rectangle rct = Rectangle.Empty;
        //            int sindx, iindx;
        //            int spc, ipc;
        //            int skpx = Convert.ToInt32((bmpMatch.Width - 1) / (double)10);
        //            if (skpx < 1 | ExactMatch)
        //                skpx = 1;
        //            int skpy = Convert.ToInt32((bmpMatch.Height - 1) / (double)10);
        //            if (skpy < 1 | ExactMatch)
        //                skpy = 1;
        //            for (int si = 0; si <= ScreenByts.Length - 1; si += 3)
        //            {
        //                FoundMatch = true;
        //                for (int iy = 0; iy <= ImgBmd.Height - 1; iy += skpy)
        //                {
        //                    for (int ix = 0; ix <= ImgBmd.Width - 1; ix += skpx)
        //                    {
        //                        sindx = (iy * ScreenBmd.Stride) + (ix * 3) + si;
        //                        iindx = (iy * ImgBmd.Stride) + (ix * 3);
        //                        spc = Color.FromArgb(ScreenByts[sindx + 2], ScreenByts[sindx + 1], ScreenByts[sindx]).ToArgb();
        //                        ipc = Color.FromArgb(ImgByts[iindx + 2], ImgByts[iindx + 1], ImgByts[iindx]).ToArgb();
        //                        if (spc != ipc)
        //                        {
        //                            FoundMatch = false;
        //                            iy = ImgBmd.Height - 1;
        //                            ix = ImgBmd.Width - 1;
        //                        }
        //                    }
        //                }
        //                if (FoundMatch)
        //                {
        //                    double r = si / (double)(bmpWhereFind.Width * 3);
        //                    double c = bmpWhereFind.Width * (r % 1);
        //                    if (r % 1 >= 0.5)
        //                        r -= 1;
        //                    rct.X = Convert.ToInt32(c);
        //                    rct.Y = Convert.ToInt32(r);
        //                    rct.Width = bmpMatch.Width;
        //                    rct.Height = bmpMatch.Height;
        //                    break;
        //                }
        //            }
        //            bmpMatch.UnlockBits(ImgBmd);
        //            bmpWhereFind.UnlockBits(ScreenBmd);
        //            return rct;
        //        }

        //        #endregion
    }
}
