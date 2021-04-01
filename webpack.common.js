const path = require("path");
const { CleanWebpackPlugin } = require("clean-webpack-plugin");
const MiniCssExtractPlugin = require("mini-css-extract-plugin");

module.exports = {
    entry: {
        //datatables: ["./wwwroot/scripts/datatables.ts"],
        //signalr: ["./wwwroot/scripts/signalr.ts"],
        //assetDiscovery: [
        //    "./wwwroot/scripts/datatableAssetDiscovery.ts"],
        //azureResources: [
        //    "./wwwroot/scripts/signalr.ts",
        //    "./wwwroot/scripts/signalrAzureResources.ts"
        //],
        //trackedEntity: [
        //    "./wwwroot/scripts/trackedEntity.ts",
        //],
        //icons: [
        //    "./node_modules/@coreui/icons-pro/css/brand.css",
        //    "./node_modules/@coreui/icons-pro/css/duotone.css",
        //    "./node_modules/@coreui/icons-pro/css/flag.css",
        //    "./node_modules/@coreui/icons-pro/css/linear.css",
        //    "./node_modules/@coreui/icons-pro/css/solid.css"
        ////],
        //icons: [
        //    "./Scripts/icons.ts"
        //],
        //style: [
        //    "./Styles/style.scss"
        //],
        icons: [
            "./node_modules/@coreui/icons-pro/css/linear.css",
            "./node_modules/@coreui/icons-pro/css/solid.css"
        ],
        jquery: [
            "./node_modules/jquery/dist/jquery.min.js"
        ],
        jqueryvalidation: [
            "./node_modules/jquery-validation/dist/jquery.validate.min.js",
            "./node_modules/jquery-validation-unobtrusive/dist/jquery.validate.unobtrusive.min.js"
        ],
        qrcode: [
            "./node_modules/qrcodejs2/qrcode.js"
        ],
        style: [
            "./node_modules/@coreui/coreui-pro/dist/css/coreui.css",
            "./Styles/style.scss"
        ],
        coreui: [
            "./node_modules/@coreui/coreui-pro/dist/js/coreui.js",
            "./node_modules/@coreui/chartjs/dist/js/coreui-chartjs.js",
            "./node_modules/@coreui/utils/dist/coreui-utils.js"
        ],
        site: [
            "./Scripts/site.ts"
        ]
    },
    output: {
        path: path.resolve(__dirname, "wwwroot/bundles"),
        filename: "[name].[contenthash].js",
        publicPath: "/"
    },
    resolve: {
        extensions: [".js", ".ts"]
    },
    module: {
        rules: [
            {
                test: /\.ts$/,
                use: "ts-loader"
            },
            {
                test: /\.(scss)$/,
                use: [
                    {
                        loader: MiniCssExtractPlugin.loader
                    },
                    "css-loader",
                    "sass-loader",
                ]
            },
            {
                test: /\.css$/,
                use: [
                    {
                        loader: MiniCssExtractPlugin.loader
                    },
                    "css-loader"
                ]
            },
            {
                test: /\.(eot|png|jpe?g|gif|svg|ttf|woff|otf)$/,
                use: [
                    {
                        loader: 'file-loader',
                        options: {
                            name: '[name].[contenthash].[ext]',
                            outputPath: '../bundles/css',
                            //publicPath: 'bundles',
                            //publicPath: (url, resourcePath, context) => {
                            //    const relativePath = path.relative(context, resourcePath);
                            //    return relativePath;
                            //},
                            //publicPath: 'bundles/css',
                            //postTransformPublicPath: (p) => { `__webpack_public_path__ + ${p}`},
                            esModule: false // <- here
                        }
                    }
                ]
            }
        ]
    },
    plugins: [
        new CleanWebpackPlugin(),
        new MiniCssExtractPlugin({
            filename: "css/[name].min.css"
        })
    ],
    optimization: {
        runtimeChunk: 'single',
        splitChunks: {
            cacheGroups: {
                vendor: {
                    test: /[\\/]node_modules[\\/]/,
                    name: 'vendors',
                    chunks: 'all',
                },
            },
        },
    }
    //optimization: {
    //    splitChunks: {
    //        cacheGroups: {
    //            commons: {
    //                test: /[\\/]node_modules[\\/]/,
    //                // cacheGroupKey here is `commons` as the key of the cacheGroup
    //                name(module, chunks, cacheGroupKey) {
    //                    const moduleFileName = module
    //                        .identifier()
    //                        .split('/')
    //                        .reduceRight((item) => item);
    //                    const allChunksNames = chunks.map((item) => item.name).join('~');
    //                    return `${cacheGroupKey}-${allChunksNames}-${moduleFileName}`;
    //                },
    //                chunks: 'all',
    //            },
    //        },
    //    },
    //},
    //],
    //externals: {
    //    jquery: 'jQuery'
    //}
};