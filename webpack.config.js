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
        style: [
            "./Styles/style.scss"
        ],
        coreui: [
            "./Scripts/coreui.ts"
        ],
        site: [
            "./Scripts/site.ts"
        ]
    },
    output: {
        path: path.resolve(__dirname, "wwwroot/bundles"),
        filename: "[name].min.js",
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
                    "sass-loader"
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
        minimize: false
    },
    devtool: 'inline-source-map'
};