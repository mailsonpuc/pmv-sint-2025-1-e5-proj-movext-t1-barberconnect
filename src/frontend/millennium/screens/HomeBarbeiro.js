import React from 'react';
import {
  View,
  Text,
  StyleSheet,
  TouchableOpacity,
  ImageBackground,
} from 'react-native';
import PageContainer from '../components/PageContainer.js';

export default function HomeBarbeiro({ navigation }) {
  return (
    <ImageBackground
      source={require('../assets/home-background.png')}
      style={styles.background}
    >
      <PageContainer>
        <Text style={styles.title}>Bem-vindo</Text>

        <View style={styles.buttonGroup}>
          <TouchableOpacity
            style={styles.button}
            onPress={() => navigation.navigate('AgendaBarbeiro')}
          >
            <Text style={styles.buttonText}>Agenda</Text>
          </TouchableOpacity>

          <TouchableOpacity
            style={styles.button}
            onPress={() => navigation.navigate('Historico')}
          >
            <Text style={styles.buttonText}>Histórico de Agendamentos</Text>
          </TouchableOpacity>

          <TouchableOpacity
            style={styles.button}
            onPress={() => navigation.navigate('MinhaConta')}
          >
            <Text style={styles.buttonText}>Minha Conta</Text>
          </TouchableOpacity>
        </View>
      </PageContainer>
    </ImageBackground>
  );
}

const styles = StyleSheet.create({
  background: {
    flex: 1,
  },
  title: {
    color: '#fff',
    fontSize: 24,
    fontWeight: 'bold',
    textAlign: 'center',
    marginBottom: 40,
    marginTop: 260,
  },
  buttonGroup: {
    gap: 20,
  },
  button: {
    backgroundColor: '#555',
    borderRadius: 12,
    paddingVertical: 15,
    alignItems: 'center',
  },
  buttonText: {
    color: '#fff',
    fontSize: 16,
    fontWeight: 'bold',
  },
});
