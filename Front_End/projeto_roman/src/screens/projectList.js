import React, { Component } from 'react';
import { FlatList, Image, StyleSheet, Text, TouchableOpacity, ScrollView, View } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';

import api from '../services/api';

export default class ProjectList extends Component {
    constructor(props) {
        super(props);
        this.state = {
            projectList: []

        }
    }

    logout = async () => {
        try {
            await AsyncStorage.removeItem('userToken');
            this.props.navigation.navigate('Login');
        } catch (error) {
            console.warn(error);
        }
    };



    // função para listar os projetos
    getProjects = async () => {

        // constante para armazenar o valor do token
        const valorToken = await AsyncStorage.getItem('userToken');

        // constante para armazenar a resposta da requisição
        const resposta = await api.get('/projeto', {

            // autorização
            headers: {
                'Authorization': 'Bearer ' + valorToken
            }
        })

        // atualiza o state da lista com a resposta da requisição
        this.setState({ projectList: resposta.data })

        console.warn(resposta)

        console.warn(this.state.projectList)

    }


    // faz a chamada para a função de listar quando a tela é renderizada
    componentDidMount() {

        this.getProjects();

    }


    render() {

        return (

            <View style={styles.main}>

                {/* Header */}
                <View style={styles.mainHeader}>

                    <View style={styles.mainHeaderRow}>
                        <Text style={styles.mainHeaderText}>Lista de Projetos</Text>
                    </View>

                    <View style={styles.mainHeaderLine} />

                    <TouchableOpacity
                        onPress={this.logout}
                    >
                        <Image
                            source={require('../../assets/img/logout1.png')}
                            style={styles.tabBarIcon}
                        />
                    </TouchableOpacity>

                    <View>

                        <TouchableOpacity
                            onPress={this.getProjects}
                        >
                            <Image
                                source={require('../../assets/img/update.png')}
                                style={styles.tabBarIcon}
                            />
                        </TouchableOpacity>

                    </View>



                </View>

                {/* Lista */}
                <ScrollView style={styles.mainBody}>

                    <FlatList
                        contentContainerStyle={styles.mainBodyContent}
                        data={this.state.projectList}
                        keyExtractor={item => item.IdProjeto}
                        renderItem={this.renderItem}
                    />

                </ScrollView>

            </View>
        );
    }

    renderItem = ({ item }) => (

        <View style={styles.flatItemRow}>

            <View style={styles.flatItemContainer}>
                <Text style={styles.flatItemTitle}>{item.nomeProjeto}</Text>
                <Text style={styles.flatItemInfo}>Tema: {item.idTemaNavigation.nomeTema}</Text>
                <Text style={styles.flatItemInfo}>Descrição: {item.descricao}</Text>
                <View style={styles.mainHeaderLine} />
            </View>

        </View>
    )
}

const styles = StyleSheet.create({

    textProfessor: {
        color: '#B338F5',
        paddingTop: 15,
        fontFamily: 'Open Sans',
        fontSize: 16
    },

    main: {
        flex: 1,
        backgroundColor: '#FFF'
    },

    // cabeçalho
    mainHeader: {
        flex: 1,
        justifyContent: 'center',
        alignItems: 'center',
        // backgroundColor: 'blue'
    },

    mainHeaderRow: {
        flexDirection: 'row'
    },

    tabBarIcon: {
        width: 25,
        height: 25,
        marginTop: 15,
        tintColor: '#B338F5'
    },

    // texto do cabeçalho
    mainHeaderText: {
        fontSize: 16,
        letterSpacing: 2,
        color: '#B338F5',
        fontFamily: 'Open Sans'
    },

    // linha de separação do cabeçalho
    mainHeaderLine: {
        width: 180,
        paddingTop: 10,
        borderBottomColor: '#B338F5',
        borderBottomWidth: 1,
    },

    // conteúdo do body
    mainBody: {
        flex: 4,
        // backgroundColor: 'red'
    },

    // conteúdo da lista
    mainBodyContent: {
        paddingTop: 30,
        paddingRight: 50,
        paddingLeft: 50
    },

    flatItemRow: {
        flexDirection: 'row',
        borderBottomWidth: 1,
        borderBottomColor: '#FFF',
        marginTop: 30
    },

    flatItemContainer: {
        flex: 1
    },

    flatItemTitle: {
        fontSize: 16,
        color: '#561B75',
        fontFamily: 'Open Sans Light'
    },

    flatItemInfo: {
        fontSize: 12,
        // #RRGGBB
        // #RGB
        color: '#B338F5',
        lineHeight: 20,
        fontFamily: 'Open Sans Light'
    }

});